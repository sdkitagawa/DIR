using System;
using System.Diagnostics;
using System.IO;
using DiscordIconReplacer.Constants;

namespace DiscordIconReplacer.Services;

public class AppIconReplacer : IIconReplacer
{
    public void ReplaceAppIcon(string targetDir, string sourceIconPath)
    {
        if (string.IsNullOrWhiteSpace(targetDir))
            return;

        if (!Directory.Exists(targetDir))
            return;

        if (string.IsNullOrWhiteSpace(sourceIconPath) || !File.Exists(sourceIconPath))
            return;

        var destinationPath = Path.Combine(targetDir, "app.ico");
        File.Copy(sourceIconPath, destinationPath, overwrite: true);

        foreach (var subDir in Directory.GetDirectories(targetDir))
        {
            if (!VersionPatterns.DiscordVersionFolder.IsMatch(Path.GetFileName(subDir)))
                continue;

            try
            {
                File.Copy(sourceIconPath, Path.Combine(subDir, "app.ico"), overwrite: true);
            }
            catch (IOException ex)
            {
                Debug.WriteLine($"Failed to replace icon in '{subDir}': {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine($"Failed to replace icon in '{subDir}': {ex.Message}");
            }
        }
    }
}
