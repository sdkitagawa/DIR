using System;
using System.IO;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;
using FluentAssertions;
using Xunit;

namespace DiscordIconReplacer.Tests.Services;

public class StartMenuShortcutLocatorTests : IDisposable
{
    private readonly string _testDirectory;
    private readonly StartMenuShortcutLocator _locator;

    public StartMenuShortcutLocatorTests()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), $"DIR_ShortcutTest_{Guid.NewGuid():N}");
        Directory.CreateDirectory(_testDirectory);
        _locator = new StartMenuShortcutLocator();
    }

    public void Dispose()
    {
        if (Directory.Exists(_testDirectory))
            Directory.Delete(_testDirectory, recursive: true);
    }

    [Fact]
    public void BuildRequests_NullStartMenuRoot_ReturnsEmpty()
    {
        var result = _locator.BuildRequests(null, new[] { "/some/path" });

        result.Should().BeEmpty();
    }

    [Fact]
    public void BuildRequests_EmptyAppDirectories_ReturnsEmpty()
    {
        var result = _locator.BuildRequests(_testDirectory, new string[0]);

        result.Should().BeEmpty();
    }

    [Fact]
    public void BuildRequests_NullAppDirectories_ReturnsEmpty()
    {
        var result = _locator.BuildRequests(_testDirectory, null);

        result.Should().BeEmpty();
    }

    [Fact]
    public void BuildRequests_EmptyStartMenuRoot_ReturnsEmpty()
    {
        var result = _locator.BuildRequests("", new[] { "/some/path" });

        result.Should().BeEmpty();
    }

    [Fact]
    public void BuildRequests_NonExistentStartMenuRoot_ReturnsEmpty()
    {
        var result = _locator.BuildRequests(@"C:\NonExistentPath12345", new[] { "/some/path" });

        result.Should().BeEmpty();
    }

    [Fact]
    public void BuildRequests_NullAppDirectoryInList_SkipsIt()
    {
        var result = _locator.BuildRequests(_testDirectory, new string[] { null });

        result.Should().BeEmpty();
    }
}
