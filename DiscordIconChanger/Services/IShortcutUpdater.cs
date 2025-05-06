using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordIconReplacer.Services
{
    public interface IShortcutUpdater
    {
        void UpdateIcon(string shortcutPath, string iconPath);
    }
}