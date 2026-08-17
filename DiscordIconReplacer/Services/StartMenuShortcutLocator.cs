using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using DiscordIconReplacer.Models;
using IWsh = IWshRuntimeLibrary;

namespace DiscordIconReplacer.Services
{
    public class StartMenuShortcutLocator : IStartMenuShortcutLocator
    {
        private static readonly Regex VersionFolderPattern = new Regex(@"^app-(\d+(\.\d+)+)$", RegexOptions.Compiled);

        public List<ShortcutUpdateRequest> BuildRequests(string startMenuRoot, IReadOnlyList<string> appDirectories)
        {
            var requests = new List<ShortcutUpdateRequest>();

            if (string.IsNullOrWhiteSpace(startMenuRoot) || !Directory.Exists(startMenuRoot) || appDirectories == null)
                return requests;

            foreach (var appDirectory in appDirectories)
            {
                if (string.IsNullOrWhiteSpace(appDirectory))
                    continue;

                var shortcutName = GetShortcutFileName(appDirectory);
                if (shortcutName == null)
                    continue;

                var iconPath = GetAppIconPath(appDirectory);
                if (!File.Exists(iconPath))
                    continue;

                foreach (var shortcut in FindShortcuts(startMenuRoot, shortcutName, appDirectory))
                    requests.Add(new ShortcutUpdateRequest(shortcut, iconPath));
            }

            return requests;
        }

        private static string GetShortcutFileName(string appDirectory)
        {
            var name = Path.GetFileName(appDirectory.TrimEnd('\\'));
            if (name.Equals("Discord", StringComparison.OrdinalIgnoreCase))
                return "Discord.lnk";
            if (name.Equals("DiscordPTB", StringComparison.OrdinalIgnoreCase))
                return "Discord PTB.lnk";
            if (name.Equals("DiscordCanary", StringComparison.OrdinalIgnoreCase))
                return "Discord Canary.lnk";
            return null;
        }

        private static string GetAppIconPath(string appDirectory)
        {
            var versionFolder = Directory.GetDirectories(appDirectory)
                .Select(Path.GetFileName)
                .Where(n => VersionFolderPattern.IsMatch(n))
                .Select(n => new { Version = ParseVersion(n), Folder = Path.Combine(appDirectory, n) })
                .Where(x => x.Version != null && File.Exists(Path.Combine(x.Folder, "app.ico")))
                .OrderByDescending(x => x.Version)
                .FirstOrDefault();

            if (versionFolder != null)
                return Path.Combine(versionFolder.Folder, "app.ico");

            return Path.Combine(appDirectory, "app.ico");
        }

        private static Version ParseVersion(string folderName)
        {
            var match = VersionFolderPattern.Match(folderName);
            return match.Success && Version.TryParse(match.Groups[1].Value, out var version) ? version : null;
        }

        private static List<string> FindShortcuts(string startMenuRoot, string shortcutName, string appDirectory)
        {
            try
            {
                return Directory.GetFiles(startMenuRoot, "*.lnk", SearchOption.AllDirectories)
                    .Where(f => string.Equals(Path.GetFileName(f), shortcutName, StringComparison.OrdinalIgnoreCase))
                    .Where(f => IsShortcutForApp(f, appDirectory))
                    .ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        private static bool IsShortcutForApp(string shortcutPath, string appDirectory)
        {
            try
            {
                var shell = new IWsh.WshShell();
                var shortcut = (IWsh.IWshShortcut)shell.CreateShortcut(shortcutPath);
                var target = shortcut.TargetPath;

                Marshal.FinalReleaseComObject(shortcut);
                Marshal.FinalReleaseComObject(shell);

                return target.StartsWith(appDirectory, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
