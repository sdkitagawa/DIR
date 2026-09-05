using DiscordIconReplacer.Facades;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace DiscordIconReplacer.Tests.Facades;

public class ShortcutUpdateFacadeTests
{
    private readonly Mock<IShortcutUpdater> _updaterMock;
    private readonly ShortcutUpdateFacade _facade;

    public ShortcutUpdateFacadeTests()
    {
        _updaterMock = new Mock<IShortcutUpdater>();
        _facade = new ShortcutUpdateFacade(_updaterMock.Object);
    }

    [Fact]
    public void ApplyAll_CallsUpdaterForEachRequest()
    {
        var requests = new System.Collections.Generic.List<ShortcutUpdateRequest>
        {
            new("/shortcuts/discord.lnk", "/icons/app.ico"),
            new("/shortcuts/ptb.lnk", "/icons/app.ico")
        };

        _facade.ApplyAll(requests);

        _updaterMock.Verify(u => u.UpdateIcon("/shortcuts/discord.lnk", "/icons/app.ico"), Times.Once);
        _updaterMock.Verify(u => u.UpdateIcon("/shortcuts/ptb.lnk", "/icons/app.ico"), Times.Once);
    }

    [Fact]
    public void ApplyAll_UpdaterThrows_ContinuesWithRemaining()
    {
        _updaterMock.Setup(u => u.UpdateIcon("/shortcuts/bad.lnk", It.IsAny<string>()))
            .Throws<System.Exception>();

        var requests = new System.Collections.Generic.List<ShortcutUpdateRequest>
        {
            new("/shortcuts/bad.lnk", "/icons/app.ico"),
            new("/shortcuts/good.lnk", "/icons/app.ico")
        };

        _facade.ApplyAll(requests);

        _updaterMock.Verify(u => u.UpdateIcon("/shortcuts/good.lnk", "/icons/app.ico"), Times.Once);
    }

    [Fact]
    public void ApplyAll_EmptyRequests_DoesNotCallUpdater()
    {
        var requests = new System.Collections.Generic.List<ShortcutUpdateRequest>();

        _facade.ApplyAll(requests);

        _updaterMock.Verify(u => u.UpdateIcon(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void ApplyAll_NullRequests_DoesNotThrowAndDoesNotCallUpdater()
    {
        _facade.ApplyAll(null);

        _updaterMock.Verify(u => u.UpdateIcon(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void ApplyAll_NullEntryInList_SkipsItAndContinues()
    {
        var requests = new System.Collections.Generic.List<ShortcutUpdateRequest>
        {
            null,
            new("/shortcuts/discord.lnk", "/icons/app.ico")
        };

        _facade.ApplyAll(requests);

        _updaterMock.Verify(u => u.UpdateIcon("/shortcuts/discord.lnk", "/icons/app.ico"), Times.Once);
    }
}
