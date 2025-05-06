using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;

namespace DiscordIconReplacer.Facades
{
    public class ShortcutUpdateFacade
    {
        private readonly IShortcutUpdater updater;

        public ShortcutUpdateFacade(IShortcutUpdater updater)
        {
            this.updater = updater;
        }

        public void ApplyAll(List<ShortcutUpdateRequest> requests)
        {
            foreach (var request in requests)
                updater.UpdateIcon(request.ShortcutPath, request.IconPath);
        }
    }
}
