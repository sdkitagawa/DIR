using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace DiscordIconReplacer.Services
{
    public interface IIconReplacer
    {
        void ReplaceAppIcon(string targetDir, string sourceIconPath);
    }
}
