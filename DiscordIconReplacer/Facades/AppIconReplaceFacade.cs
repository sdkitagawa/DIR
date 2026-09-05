using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;

namespace DiscordIconReplacer.Facades;

public class AppIconReplaceFacade
{
    private readonly IIconReplacer _replacer;

    public AppIconReplaceFacade(IIconReplacer replacer)
    {
        _replacer = replacer;
    }

    public void ApplyAll(string baseIconsFolder, List<AppIconReplaceRequest> requests)
    {
        if (requests == null || requests.Count == 0)
            return;

        foreach (var request in requests)
        {
            if (request == null)
                continue;

            try
            {
                var iconPath = Path.Combine(baseIconsFolder, request.IconName);
                _replacer.ReplaceAppIcon(request.TargetDir, iconPath);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Failed to replace icon for '{request.TargetDir}': {ex.Message}");
            }
        }
    }
}
