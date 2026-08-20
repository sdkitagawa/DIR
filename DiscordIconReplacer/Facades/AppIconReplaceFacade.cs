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
        foreach (var request in requests)
        {
            var iconPath = Path.Combine(baseIconsFolder, request.IconName);
            _replacer.ReplaceAppIcon(request.TargetDir, iconPath);
        }
    }
}
