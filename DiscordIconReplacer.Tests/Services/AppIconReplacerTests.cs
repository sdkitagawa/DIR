using System;
using System.IO;
using DiscordIconReplacer.Services;
using FluentAssertions;
using Xunit;

namespace DiscordIconReplacer.Tests.Services;

public class AppIconReplacerTests : IDisposable
{
    private readonly string _testDirectory;
    private readonly AppIconReplacer _replacer;

    public AppIconReplacerTests()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), $"DIR_Test_{Guid.NewGuid():N}");
        Directory.CreateDirectory(_testDirectory);
        _replacer = new AppIconReplacer();
    }

    public void Dispose()
    {
        if (Directory.Exists(_testDirectory))
            Directory.Delete(_testDirectory, recursive: true);
    }

    [Fact]
    public void ReplaceAppIcon_DirectoryDoesNotExist_DoesNotThrow()
    {
        var nonExistentDir = Path.Combine(_testDirectory, "nonexistent");
        var iconPath = CreateTestIcon("source.ico");

        var act = () => _replacer.ReplaceAppIcon(nonExistentDir, iconPath);

        act.Should().NotThrow();
    }

    [Fact]
    public void ReplaceAppIcon_EmptyDirectory_CopiesIconToRoot()
    {
        var iconPath = CreateTestIcon("source.ico");

        _replacer.ReplaceAppIcon(_testDirectory, iconPath);

        File.Exists(Path.Combine(_testDirectory, "app.ico")).Should().BeTrue();
    }

    [Fact]
    public void ReplaceAppIcon_VersionSubfolder_CopiesIconToSubfolder()
    {
        var versionDir = Path.Combine(_testDirectory, "app-1.0.0");
        Directory.CreateDirectory(versionDir);
        var iconPath = CreateTestIcon("source.ico");

        _replacer.ReplaceAppIcon(_testDirectory, iconPath);

        File.Exists(Path.Combine(versionDir, "app.ico")).Should().BeTrue();
    }

    [Fact]
    public void ReplaceAppIcon_MultipleVersionSubfolders_CopiesToAll()
    {
        var v1Dir = Path.Combine(_testDirectory, "app-1.0.0");
        var v2Dir = Path.Combine(_testDirectory, "app-2.0.0");
        Directory.CreateDirectory(v1Dir);
        Directory.CreateDirectory(v2Dir);
        var iconPath = CreateTestIcon("source.ico");

        _replacer.ReplaceAppIcon(_testDirectory, iconPath);

        File.Exists(Path.Combine(v1Dir, "app.ico")).Should().BeTrue();
        File.Exists(Path.Combine(v2Dir, "app.ico")).Should().BeTrue();
    }

    [Fact]
    public void ReplaceAppIcon_NonVersionSubfolder_DoesNotCopyToSubfolder()
    {
        var otherDir = Path.Combine(_testDirectory, "random-folder");
        Directory.CreateDirectory(otherDir);
        var iconPath = CreateTestIcon("source.ico");

        _replacer.ReplaceAppIcon(_testDirectory, iconPath);

        File.Exists(Path.Combine(otherDir, "app.ico")).Should().BeFalse();
    }

    [Fact]
    public void ReplaceAppIcon_ExistingIconFile_Overwrites()
    {
        var iconPath = CreateTestIcon("source.ico");
        var destPath = Path.Combine(_testDirectory, "app.ico");
        File.WriteAllText(destPath, "old content");

        _replacer.ReplaceAppIcon(_testDirectory, iconPath);

        File.ReadAllText(destPath).Should().NotBe("old content");
    }

    private string CreateTestIcon(string fileName)
    {
        var path = Path.Combine(_testDirectory, fileName);
        File.WriteAllText(path, "fake icon content");
        return path;
    }
}
