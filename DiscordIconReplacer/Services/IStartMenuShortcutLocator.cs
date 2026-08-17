using System;
using System.Collections.Generic;
using DiscordIconReplacer.Models;

namespace DiscordIconReplacer.Services
{
    public interface IStartMenuShortcutLocator
    {
        List<ShortcutUpdateRequest> BuildRequests(string startMenuRoot, IReadOnlyList<string> appDirectories);
    }
}
