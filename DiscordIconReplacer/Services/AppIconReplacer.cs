using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DiscordIconReplacer.Services;

namespace DiscordIconReplacer.Services
{
    public class AppIconReplacer : IIconReplacer
    {
        private static readonly Regex VersionFolderPattern = new Regex(@"^app-\d+(\.\d+)+$", RegexOptions.Compiled);

        public void ReplaceAppIcon(string targetDir, string sourceIconPath)
        {
            var destinationPath = Path.Combine(targetDir, "app.ico");
            File.Copy(sourceIconPath, destinationPath, overwrite: true);

            if (!Directory.Exists(targetDir))
                return;

            foreach (var subDir in Directory.GetDirectories(targetDir))
            {
                if (VersionFolderPattern.IsMatch(Path.GetFileName(subDir)))
                    File.Copy(sourceIconPath, Path.Combine(subDir, "app.ico"), overwrite: true);
            }
        }
    }
}