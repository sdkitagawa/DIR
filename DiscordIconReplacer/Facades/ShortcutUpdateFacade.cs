using System.Collections.Generic;
using System.Diagnostics;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;

namespace DiscordIconReplacer.Facades;

public class ShortcutUpdateFacade
{
    private readonly IShortcutUpdater _updater;

    public ShortcutUpdateFacade(IShortcutUpdater updater)
    {
        _updater = updater;
    }

    public void ApplyAll(List<ShortcutUpdateRequest> requests)
    {
        foreach (var request in requests)
        {
            try
            {
                _updater.UpdateIcon(request.ShortcutPath, request.IconPath);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Failed to update shortcut '{request.ShortcutPath}': {ex.Message}");
            }
        }
    }
}
