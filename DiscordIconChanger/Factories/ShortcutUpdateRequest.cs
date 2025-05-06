using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordIconReplacer.Models
{
    public class ShortcutUpdateRequest
    {
        public string ShortcutPath { get; }
        public string IconPath { get; }

        public ShortcutUpdateRequest(string shortcutPath, string iconPath)
        {
            ShortcutPath = shortcutPath;
            IconPath = iconPath;
        }
    }
}