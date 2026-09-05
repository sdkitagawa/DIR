using System.IO;
using DiscordIconReplacer.Services;
using FluentAssertions;
using Xunit;

namespace DiscordIconReplacer.Tests.Services;

public class ShortcutUpdaterTests
{
    private readonly ShortcutUpdater _updater = new ShortcutUpdater();

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void UpdateIcon_BlankShortcutPath_DoesNotThrow(string shortcutPath)
    {
        var act = () => _updater.UpdateIcon(shortcutPath, "C:\\icons\\app.ico");

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void UpdateIcon_BlankIconPath_DoesNotThrow(string iconPath)
    {
        var act = () => _updater.UpdateIcon("C:\\shortcuts\\Discord.lnk", iconPath);

        act.Should().NotThrow();
    }

    [Fact]
    public void UpdateIcon_NonexistentShortcut_DoesNotThrow()
    {
        var act = () => _updater.UpdateIcon("C:\\nonexistent\\Discord.lnk", "C:\\icons\\app.ico");

        act.Should().NotThrow();
    }

    [Fact]
    public void UpdateIcon_NonLnkExtension_DoesNotThrow()
    {
        var file = Path.Combine(Path.GetTempPath(), $"DIR_Shortcut_{System.Guid.NewGuid():N}.txt");
        File.WriteAllText(file, string.Empty);
        try
        {
            var act = () => _updater.UpdateIcon(file, "C:\\icons\\app.ico");

            act.Should().NotThrow();
        }
        finally
        {
            File.Delete(file);
        }
    }
}