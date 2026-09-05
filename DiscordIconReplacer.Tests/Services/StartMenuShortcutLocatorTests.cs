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

    [Fact]
    public void BuildRequests_NonexistentAppDirectory_SkipsIt()
    {
        var result = _locator.BuildRequests(_testDirectory, new[] { Path.Combine(_testDirectory, "does-not-exist") });

        result.Should().BeEmpty();
    }

    [Fact]
    public void BuildRequests_UnknownAppDirectoryName_SkipsIt()
    {
        var unknownDir = Path.Combine(_testDirectory, "SomeOtherApp");
        Directory.CreateDirectory(unknownDir);

        var result = _locator.BuildRequests(_testDirectory, new[] { unknownDir });

        result.Should().BeEmpty();
    }

    [Fact]
    public void BuildRequests_ValidAppDirectoryWithIcon_NoShortcutsFound_ReturnsEmpty()
    {
        var discordDir = Path.Combine(_testDirectory, "Discord");
        Directory.CreateDirectory(discordDir);
        File.WriteAllText(Path.Combine(discordDir, "app.ico"), "icon");

        var result = _locator.BuildRequests(_testDirectory, new[] { discordDir });

        result.Should().BeEmpty();
    }

    [Fact]
    public void GetAppIconPath_VersionFolders_ReturnsHighestVersionIcon()
    {
        var root = Path.Combine(_testDirectory, "Discord");
        var v1Dir = Directory.CreateDirectory(Path.Combine(root, "app-1.0.0"));
        var v2Dir = Directory.CreateDirectory(Path.Combine(root, "app-2.5.0"));
        File.WriteAllText(Path.Combine(v1Dir.FullName, "app.ico"), "v1");
        File.WriteAllText(Path.Combine(v2Dir.FullName, "app.ico"), "v2");

        var result = StartMenuShortcutLocator.GetAppIconPath(root);

        result.Should().Be(Path.Combine(v2Dir.FullName, "app.ico"));
    }

    [Fact]
    public void GetAppIconPath_VersionFolderWithoutIcon_FallsBackToPopulatedVersionFolder()
    {
        var root = Path.Combine(_testDirectory, "Discord");
        var emptyVersionDir = Directory.CreateDirectory(Path.Combine(root, "app-3.0.0"));
        var populatedVersionDir = Directory.CreateDirectory(Path.Combine(root, "app-1.0.0"));
        File.WriteAllText(Path.Combine(populatedVersionDir.FullName, "app.ico"), "v1");

        var result = StartMenuShortcutLocator.GetAppIconPath(root);

        result.Should().Be(Path.Combine(populatedVersionDir.FullName, "app.ico"));
    }

    [Fact]
    public void GetAppIconPath_NoVersionFolders_ReturnsRootAppIcon()
    {
        var root = Path.Combine(_testDirectory, "Discord");
        Directory.CreateDirectory(root);
        File.WriteAllText(Path.Combine(root, "app.ico"), "root");

        var result = StartMenuShortcutLocator.GetAppIconPath(root);

        result.Should().Be(Path.Combine(root, "app.ico"));
    }

    [Fact]
    public void GetAppIconPath_NoIconFiles_StillReturnsRootAppIconPath()
    {
        var root = Path.Combine(_testDirectory, "Discord");
        Directory.CreateDirectory(root);

        var result = StartMenuShortcutLocator.GetAppIconPath(root);

        result.Should().Be(Path.Combine(root, "app.ico"));
    }

    [Fact]
    public void GetAppIconPath_NonexistentFolder_DoesNotThrow()
    {
        var root = Path.Combine(_testDirectory, "Discord");

        var result = StartMenuShortcutLocator.GetAppIconPath(root);

        result.Should().Be(Path.Combine(root, "app.ico"));
    }

    [Fact]
    public void GetAppIconPath_NonMatchingFolderName_IgnoresIt()
    {
        var root = Path.Combine(_testDirectory, "Discord");
        var weirdDir = Directory.CreateDirectory(Path.Combine(root, "app-folder"));
        File.WriteAllText(Path.Combine(weirdDir.FullName, "app.ico"), "icon");

        var result = StartMenuShortcutLocator.GetAppIconPath(root);

        result.Should().Be(Path.Combine(root, "app.ico"));
    }
}
