using System.IO;
using DiscordIconReplacer.Constants;

namespace DiscordIconReplacer.Services;

public class AppIconReplacer : IIconReplacer
{
    public void ReplaceAppIcon(string targetDir, string sourceIconPath)
    {
        if (!Directory.Exists(targetDir))
            return;

        var destinationPath = Path.Combine(targetDir, "app.ico");
        File.Copy(sourceIconPath, destinationPath, overwrite: true);

        foreach (var subDir in Directory.GetDirectories(targetDir))
        {
            if (VersionPatterns.DiscordVersionFolder.IsMatch(Path.GetFileName(subDir)))
                File.Copy(sourceIconPath, Path.Combine(subDir, "app.ico"), overwrite: true);
        }
    }
}
