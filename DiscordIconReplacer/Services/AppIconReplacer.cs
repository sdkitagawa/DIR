using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordIconReplacer.Services;

namespace DiscordIconReplacer.Services
{
    public class AppIconReplacer : IIconReplacer
    {
        public void ReplaceAppIcon(string targetDir, string sourceIconPath)
        {
            var destinationPath = Path.Combine(targetDir, "app.ico");
            File.Copy(sourceIconPath, destinationPath, overwrite: true);
        }
    }
}