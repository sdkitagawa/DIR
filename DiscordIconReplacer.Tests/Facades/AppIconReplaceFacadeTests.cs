using System.IO;
using DiscordIconReplacer.Facades;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace DiscordIconReplacer.Tests.Facades;

public class AppIconReplaceFacadeTests
{
    private readonly Mock<IIconReplacer> _replacerMock;
    private readonly AppIconReplaceFacade _facade;

    public AppIconReplaceFacadeTests()
    {
        _replacerMock = new Mock<IIconReplacer>();
        _facade = new AppIconReplaceFacade(_replacerMock.Object);
    }

    [Fact]
    public void ApplyAll_CallsReplacerForEachRequest()
    {
        var requests = new System.Collections.Generic.List<AppIconReplaceRequest>
        {
            new("/path/discord", "icon1.ico"),
            new("/path/discordptb", "icon2.ico")
        };

        _facade.ApplyAll("/icons", requests);

        _replacerMock.Verify(r => r.ReplaceAppIcon("/path/discord", Path.Combine("/icons", "icon1.ico")), Times.Once);
        _replacerMock.Verify(r => r.ReplaceAppIcon("/path/discordptb", Path.Combine("/icons", "icon2.ico")), Times.Once);
    }

    [Fact]
    public void ApplyAll_EmptyRequests_DoesNotCallReplacer()
    {
        var requests = new System.Collections.Generic.List<AppIconReplaceRequest>();

        _facade.ApplyAll("/icons", requests);

        _replacerMock.Verify(r => r.ReplaceAppIcon(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void ApplyAll_SingleRequest_CallsReplacerOnce()
    {
        var requests = new System.Collections.Generic.List<AppIconReplaceRequest>
        {
            new("/path/discord", "icon.ico")
        };

        _facade.ApplyAll("/icons", requests);

        _replacerMock.Verify(r => r.ReplaceAppIcon("/path/discord", Path.Combine("/icons", "icon.ico")), Times.Once);
    }

    [Fact]
    public void ApplyAll_NullRequests_DoesNotThrowAndDoesNotCallReplacer()
    {
        _facade.ApplyAll("/icons", null);

        _replacerMock.Verify(r => r.ReplaceAppIcon(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void ApplyAll_NullEntryInList_SkipsItAndContinues()
    {
        var requests = new System.Collections.Generic.List<AppIconReplaceRequest>
        {
            null,
            new("/path/discord", "icon.ico")
        };

        _facade.ApplyAll("/icons", requests);

        _replacerMock.Verify(r => r.ReplaceAppIcon("/path/discord", Path.Combine("/icons", "icon.ico")), Times.Once);
    }

    [Fact]
    public void ApplyAll_ReplacerThrows_ContinuesWithRemainingRequests()
    {
        _replacerMock.Setup(r => r.ReplaceAppIcon("/path/bad", It.IsAny<string>()))
            .Throws<System.Exception>();

        var requests = new System.Collections.Generic.List<AppIconReplaceRequest>
        {
            new("/path/bad", "bad.ico"),
            new("/path/good", "good.ico")
        };

        _facade.ApplyAll("/icons", requests);

        _replacerMock.Verify(r => r.ReplaceAppIcon("/path/good", Path.Combine("/icons", "good.ico")), Times.Once);
    }
}
