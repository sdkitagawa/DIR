namespace DiscordIconReplacer.Services;

public interface IShortcutUpdater
{
    void UpdateIcon(string shortcutPath, string iconPath);
}
