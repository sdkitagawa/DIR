using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;

namespace DiscordIconReplacer.Facades
{
    public class AppIconReplaceFacade
    {
        private readonly IIconReplacer replacer;

        public AppIconReplaceFacade(IIconReplacer replacer)
        {
            this.replacer = replacer;
        }

        public void ApplyAll(string baseIconsFolder, List<AppIconReplaceRequest> requests)
        {
            foreach (var request in requests)
            {
                var iconPath = Path.Combine(baseIconsFolder, request.IconName);
                replacer.ReplaceAppIcon(request.TargetDir, iconPath);
            }
        }
    }
}
