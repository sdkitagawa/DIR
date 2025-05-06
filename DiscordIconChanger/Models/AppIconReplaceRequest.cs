using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordIconReplacer.Models
{
    public class AppIconReplaceRequest
    {
        public string TargetDir { get; }
        public string IconName { get; }

        public AppIconReplaceRequest(string targetDir, string iconName)
        {
            TargetDir = targetDir;
            IconName = iconName;
        }
    }
}
