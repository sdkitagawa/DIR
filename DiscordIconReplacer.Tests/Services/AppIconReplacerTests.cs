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

    [Fact]
    public void ReplaceAppIcon_NonexistentSourceIcon_DoesNotCreateFiles()
    {
        var missingIcon = Path.Combine(_testDirectory, "missing.ico");

        _replacer.ReplaceAppIcon(_testDirectory, missingIcon);

        File.Exists(Path.Combine(_testDirectory, "app.ico")).Should().BeFalse();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ReplaceAppIcon_BlankTargetDir_DoesNotThrow(string targetDir)
    {
        var iconPath = CreateTestIcon("source.ico");

        var act = () => _replacer.ReplaceAppIcon(targetDir, iconPath);

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ReplaceAppIcon_BlankSourceIcon_DoesNotCreateFiles(string sourceIcon)
    {
        _replacer.ReplaceAppIcon(_testDirectory, sourceIcon);

        File.Exists(Path.Combine(_testDirectory, "app.ico")).Should().BeFalse();
    }

    [Fact]
    public void ReplaceAppIcon_SourceIconIsDirectory_DoesNotCreateFiles()
    {
        var dirAsIcon = Path.Combine(_testDirectory, "not-an-icon");
        Directory.CreateDirectory(dirAsIcon);

        _replacer.ReplaceAppIcon(_testDirectory, dirAsIcon);

        File.Exists(Path.Combine(_testDirectory, "app.ico")).Should().BeFalse();
    }

    [Fact]
    public void ReplaceAppIcon_NonNumericSubfolder_DoesNotMatchVersionPattern()
    {
        var withDigits = Path.Combine(_testDirectory, "app-1.0.0");
        var noDigits = Path.Combine(_testDirectory, "app-folder");
        Directory.CreateDirectory(withDigits);
        Directory.CreateDirectory(noDigits);
        var iconPath = CreateTestIcon("source.ico");

        _replacer.ReplaceAppIcon(_testDirectory, iconPath);

        File.Exists(Path.Combine(withDigits, "app.ico")).Should().BeTrue();
        File.Exists(Path.Combine(noDigits, "app.ico")).Should().BeFalse();
    }

    private string CreateTestIcon(string fileName)
    {
        var path = Path.Combine(_testDirectory, fileName);
        File.WriteAllText(path, "fake icon content");
        return path;
    }
}
