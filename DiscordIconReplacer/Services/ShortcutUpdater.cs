using System;
using System.IO;
using System.Runtime.InteropServices;
using IWsh = IWshRuntimeLibrary;

namespace DiscordIconReplacer.Services;

public class ShortcutUpdater : IShortcutUpdater
{
    public void UpdateIcon(string shortcutPath, string iconPath)
    {
        if (!File.Exists(shortcutPath) || !string.Equals(Path.GetExtension(shortcutPath), ".lnk", StringComparison.OrdinalIgnoreCase))
            return;

        var shell = new IWsh.WshShell();
        var shortcut = (IWsh.IWshShortcut)shell.CreateShortcut(shortcutPath);
        shortcut.IconLocation = $"{iconPath}, 0";
        shortcut.Save();

        Marshal.FinalReleaseComObject(shortcut);
        Marshal.FinalReleaseComObject(shell);
    }
}
