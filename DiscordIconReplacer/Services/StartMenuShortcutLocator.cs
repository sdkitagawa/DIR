using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using DiscordIconReplacer.Constants;
using DiscordIconReplacer.Models;
using IWsh = IWshRuntimeLibrary;

namespace DiscordIconReplacer.Services;

public class StartMenuShortcutLocator
{
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
            .Where(n => VersionPatterns.DiscordVersionFolder.IsMatch(n))
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
        var match = VersionPatterns.DiscordVersionFolder.Match(folderName);
        return match.Success && Version.TryParse(match.Groups[1].Value, out var version) ? version : null;
    }

    private static List<string> FindShortcuts(string startMenuRoot, string shortcutName, string appDirectory)
    {
        var matches = new List<string>();
        foreach (var file in EnumerateShortcutFiles(startMenuRoot))
        {
            if (!string.Equals(Path.GetFileName(file), shortcutName, StringComparison.OrdinalIgnoreCase))
                continue;
            if (!IsShortcutForApp(file, appDirectory))
                continue;
            matches.Add(file);
        }
        return matches;
    }

    private static IEnumerable<string> EnumerateShortcutFiles(string root)
    {
        var pending = new Stack<string>();
        pending.Push(root);

        while (pending.Count > 0)
        {
            var current = pending.Pop();

            List<string> files;
            List<string> directories;
            try
            {
                files = Directory.GetFiles(current, "*.lnk").ToList();
                directories = Directory.GetDirectories(current).ToList();
            }
            catch
            {
                continue;
            }

            foreach (var directory in directories)
                pending.Push(directory);

            foreach (var file in files)
                yield return file;
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

            return !string.IsNullOrEmpty(target) &&
                target.StartsWith(appDirectory, StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }
}
