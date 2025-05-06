using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordIconReplacer.Models;

namespace DiscordIconReplacer.Factories
{
    public class ShortcutUpdateRequestFactory
    {
        public List<ShortcutUpdateRequest> CreateFromFormInputs(string[] shortcutPaths, string[] iconPaths)
        {
            var requests = new List<ShortcutUpdateRequest>();
            for (int i = 0; i < shortcutPaths.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(shortcutPaths[i]) && !string.IsNullOrWhiteSpace(iconPaths[i]))
                    requests.Add(new ShortcutUpdateRequest(shortcutPaths[i], iconPaths[i]));
            }
            return requests;
        }
    }
}
