using DiscordIconReplacer.Services;
using FluentAssertions;
using Xunit;

namespace DiscordIconReplacer.Tests.Services;

public class FileDialogServiceTests
{
    private readonly FileDialogService _service = new();

    [Fact]
    public void ShowFileDialog_ReturnsStringType()
    {
        var result = _service.ShowFileDialog("Icon", "ico");

        result.Should().BeAssignableTo<string>();
    }

    [Fact]
    public void ShowFolderDialog_ReturnsStringType()
    {
        var result = _service.ShowFolderDialog("Select folder", @"C:\");

        result.Should().BeAssignableTo<string>();
    }
}
