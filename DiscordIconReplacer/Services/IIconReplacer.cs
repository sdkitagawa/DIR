namespace DiscordIconReplacer.Services;

public interface IIconReplacer
{
    void ReplaceAppIcon(string targetDir, string sourceIconPath);
}
