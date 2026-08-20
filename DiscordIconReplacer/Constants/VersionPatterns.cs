using System.Text.RegularExpressions;

namespace DiscordIconReplacer.Constants;

internal static class VersionPatterns
{
    internal static readonly Regex DiscordVersionFolder = new(@"^app-(\d+(\.\d+)+)$", RegexOptions.Compiled);
}
