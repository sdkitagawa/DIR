using System;
using DiscordIconReplacer.Services;
using FluentAssertions;
using Xunit;

namespace DiscordIconReplacer.Tests.Services;

public class DialogFilterTests
{
    [Fact]
    public void Build_WithFileTypeAndExtension_ReturnsWindowsFilterPattern()
    {
        var result = DialogFilter.Build("Icon", "ico");

        result.Should().Be("Icon (*.ico)|*.ico");
    }

    [Fact]
    public void Build_WithCaseSensitiveExtension_PreservesCase()
    {
        var result = DialogFilter.Build("Bitmap", "PNG");

        result.Should().Be("Bitmap (*.PNG)|*.PNG");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Build_BlankFileType_Throws(string fileType)
    {
        var act = () => DialogFilter.Build(fileType, "ico");

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Build_BlankExtension_Throws(string extension)
    {
        var act = () => DialogFilter.Build("Icon", extension);

        act.Should().Throw<ArgumentException>();
    }
}