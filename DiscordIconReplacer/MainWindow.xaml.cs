using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DiscordIconReplacer.Controls;
using DiscordIconReplacer.Facades;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;
using DiscordIconReplacer.SystemServices;
using DiscordIconReplacer.Properties;

namespace DiscordIconReplacer;

public partial class MainWindow : Window
{
    private const int DwmwaWindowCornerPreference = 33;
    private const int DwmwcpRound = 2;
    private const int DwmwaNcRenderingPolicy = 2;
    private const int DwmncrpDisabled = 2;
    private const string DefaultIconsFolderName = "icons";

    private readonly IFileDialogService _dialogService;
    private readonly IIconReplacer _replacer;
    private readonly IShortcutUpdater _shortcutUpdater;

    private readonly DirectoryRow _discordFolderRow;
    private readonly DirectoryRow _discordIconRow;
    private readonly DirectoryRow _ptbFolderRow;
    private readonly DirectoryRow _ptbIconRow;
    private readonly DirectoryRow _canaryFolderRow;
    private readonly DirectoryRow _canaryIconRow;

    public MainWindow()
        : this(new FileDialogService(), new AppIconReplacer(), new ShortcutUpdater())
    {
    }

    public MainWindow(IFileDialogService dialogService, IIconReplacer replacer, IShortcutUpdater shortcutUpdater)
    {
        if (dialogService == null) throw new ArgumentNullException(nameof(dialogService));
        if (replacer == null) throw new ArgumentNullException(nameof(replacer));
        if (shortcutUpdater == null) throw new ArgumentNullException(nameof(shortcutUpdater));

        _dialogService = dialogService;
        _replacer = replacer;
        _shortcutUpdater = shortcutUpdater;

        InitializeComponent();

        SizeWindowToWorkArea();

        LoadBrandIcon();

        _discordFolderRow = CreateRow("Discord Folder", "Select the main Discord installation folder.", IconKind.Folder, isFolder: true);
        _discordIconRow = CreateRow("Discord Icon", "Select the Discord icon file.", IconKind.Tag, isFolder: false, GetDefaultIconPath("discord.ico"));
        _ptbFolderRow = CreateRow("Discord PTB Folder", "Select the Discord PTB installation folder.", IconKind.Folder, isFolder: true);
        _ptbIconRow = CreateRow("Discord PTB Icon", "Select the Discord PTB icon file.", IconKind.Tag, isFolder: false, GetDefaultIconPath("ptb.ico"));
        _canaryFolderRow = CreateRow("Discord Canary Folder", "Select the Discord Canary installation folder.", IconKind.Folder, isFolder: true);
        _canaryIconRow = CreateRow("Discord Canary Icon", "Select the Discord Canary icon file.", IconKind.Tag, isFolder: false, GetDefaultIconPath("canary.ico"));

        _canaryIconRow.DividerVisibility = Visibility.Collapsed;

        RowsPanel.Children.Add(_discordFolderRow);
        RowsPanel.Children.Add(_discordIconRow);
        RowsPanel.Children.Add(_ptbFolderRow);
        RowsPanel.Children.Add(_ptbIconRow);
        RowsPanel.Children.Add(_canaryFolderRow);
        RowsPanel.Children.Add(_canaryIconRow);

        LoadSettings();

        CacheToggle.IsChecked = Settings.Default.RestartExplorerAfterApply;
        CacheToggle_Changed(null, null);
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);

        var handle = new WindowInteropHelper(this).Handle;
        if (handle == IntPtr.Zero)
            return;

        int preference = DwmwcpRound;
        DwmSetWindowAttribute(handle, DwmwaWindowCornerPreference, ref preference, sizeof(int));

        int noRendering = DwmncrpDisabled;
        DwmSetWindowAttribute(handle, DwmwaNcRenderingPolicy, ref noRendering, sizeof(int));
    }

    private void SizeWindowToWorkArea()
    {
        var work = SystemParameters.WorkArea;
        Width = Math.Max(MinWidth, Math.Min(work.Width * 0.95, work.Width));
        MaxHeight = work.Height;
        ContentScroller.MaxHeight = Math.Max(200, work.Height - 140);
    }

    [DllImport("dwmapi.dll", PreserveSig = true)]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    private DirectoryRow CreateRow(string title, string description, IconKind iconKind, bool isFolder, string iconImagePath = "")
    {
        return new DirectoryRow
        {
            Title = title,
            Description = description,
            IconKind = iconKind,
            IsFolder = isFolder,
            IconImagePath = iconImagePath,
            DialogService = _dialogService
        };
    }

    private static string GetDefaultIconPath(string fileName)
    {
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultIconsFolderName, fileName);
    }

    private void LoadBrandIcon()
    {
        var path = GetDefaultIconPath("dir_box.ico");
        if (!File.Exists(path))
            return;

        try
        {
            using (var stream = File.OpenRead(path))
            {
                BrandIcon.Source = BitmapFrame.Create(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            }

            RenderOptions.SetBitmapScalingMode(BrandIcon, BitmapScalingMode.Fant);
        }
        catch (IOException)
        {
        }
        catch (UnauthorizedAccessException)
        {
        }
    }

    private string[] FolderPaths => new[]
    {
        _discordFolderRow.PathValue,
        _ptbFolderRow.PathValue,
        _canaryFolderRow.PathValue
    };

    private (string folder, string icon)[] IconPairs => new[]
    {
        (_discordFolderRow.PathValue, _discordIconRow.PathValue),
        (_ptbFolderRow.PathValue, _ptbIconRow.PathValue),
        (_canaryFolderRow.PathValue, _canaryIconRow.PathValue)
    };

    private void LoadSettings()
    {
        _discordFolderRow.PathValue = DefaultFolderPath("Discord", Settings.Default.DiscordShortcut);
        _discordIconRow.PathValue = Settings.Default.DiscordIcon;
        _ptbFolderRow.PathValue = DefaultFolderPath("DiscordPTB", Settings.Default.DiscordPTBShortcut);
        _ptbIconRow.PathValue = Settings.Default.DiscordPTBIcon;
        _canaryFolderRow.PathValue = DefaultFolderPath("DiscordCanary", Settings.Default.DiscordCanaryShortcut);
        _canaryIconRow.PathValue = Settings.Default.DiscordCanaryIcon;
    }

    private static string DefaultFolderPath(string folderName, string savedPath)
    {
        if (!string.IsNullOrWhiteSpace(savedPath))
            return savedPath;

        var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return string.IsNullOrWhiteSpace(localAppData)
            ? string.Empty
            : Path.Combine(localAppData, folderName);
    }

    private void CacheToggle_Changed(object sender, RoutedEventArgs e)
    {
        bool isChecked = CacheToggle.IsChecked == true;
        CacheBoxChecked.Opacity = isChecked ? 1 : 0;
        CacheBoxUnchecked.Opacity = isChecked ? 0 : 1;
    }

    private void ApplyButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var appRequests = new List<AppIconReplaceRequest>();
            foreach (var (folder, icon) in IconPairs)
            {
                if (string.IsNullOrWhiteSpace(folder) || string.IsNullOrWhiteSpace(icon) || !Directory.Exists(folder))
                    continue;

                appRequests.Add(new AppIconReplaceRequest(
                    folder,
                    Path.GetFileName(icon)));
            }

            if (appRequests.Count > 0)
            {
                var baseIconsFolder = Path.GetDirectoryName(_discordIconRow.PathValue);
                if (!string.IsNullOrWhiteSpace(baseIconsFolder))
                    new AppIconReplaceFacade(_replacer).ApplyAll(baseIconsFolder, appRequests);
            }

            var dirs = new List<string>();
            foreach (var path in FolderPaths)
            {
                if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
                    dirs.Add(path);
            }

            if (dirs.Count > 0)
            {
                var startMenuRoot = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
                var requests = new StartMenuShortcutLocator().BuildRequests(startMenuRoot, dirs);
                if (requests.Count > 0)
                    new ShortcutUpdateFacade(_shortcutUpdater).ApplyAll(requests);
            }

            if (CacheToggle.IsChecked == true)
                new SystemService().RestartExplorer();

            Toast.Show("Icons applied.");
        }
        catch (Exception ex)
        {
            Toast.Show($"Failed to apply icons: {ex.Message}");
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        Settings.Default.DiscordShortcut = _discordFolderRow.PathValue;
        Settings.Default.DiscordIcon = _discordIconRow.PathValue;
        Settings.Default.DiscordPTBShortcut = _ptbFolderRow.PathValue;
        Settings.Default.DiscordPTBIcon = _ptbIconRow.PathValue;
        Settings.Default.DiscordCanaryShortcut = _canaryFolderRow.PathValue;
        Settings.Default.DiscordCanaryIcon = _canaryIconRow.PathValue;
        Settings.Default.RestartExplorerAfterApply = CacheToggle.IsChecked == true;
        Settings.Default.Save();

        Toast.Show("Discord directories saved.");
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
