using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DiscordIconReplacer.Facades;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.Services;
using DiscordIconReplacer.SystemServices;

namespace DiscordIconReplacer;

public partial class MainForm : Form
{
    private const string DefaultIconsFolderName = "Icons";

    private readonly IFileDialogService _fileDialogService;
    private readonly ISystemService _systemService;
    private readonly string _defaultIconsFolder;

    public MainForm(IFileDialogService fileDialogService, ISystemService systemService)
    {
        InitializeComponent();
        _fileDialogService = fileDialogService;
        _systemService = systemService;
        _defaultIconsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultIconsFolderName);

        string discordAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Discord");
        string discordPTBAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DiscordPTB");
        string discordCanaryAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DiscordCanary");

        CheckBox_RestartExplorer.Checked = Properties.Settings.Default.RestartExplorerAfterApply;

        TextBox_DiscordShortcut.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordShortcut)
            ? discordAppDataPath
            : Properties.Settings.Default.DiscordShortcut;

        TextBox_DiscordIcon.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordIcon)
            ? Path.Combine(_defaultIconsFolder, "burble_light.ico")
            : Properties.Settings.Default.DiscordIcon;

        TextBox_DiscordPTBShortcut.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordPTBShortcut)
            ? discordPTBAppDataPath
            : Properties.Settings.Default.DiscordPTBShortcut;

        TextBox_DiscordPTBIcon.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordPTBIcon)
            ? Path.Combine(_defaultIconsFolder, "sherbet_dreamsicle.ico")
            : Properties.Settings.Default.DiscordPTBIcon;

        TextBox_DiscordCanaryShortcut.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordCanaryShortcut)
            ? discordCanaryAppDataPath
            : Properties.Settings.Default.DiscordCanaryShortcut;

        TextBox_DiscordCanaryIcon.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordCanaryIcon)
            ? Path.Combine(_defaultIconsFolder, "sakura.ico")
            : Properties.Settings.Default.DiscordCanaryIcon;
    }

    private void Button_ApplyIcons_Click(object sender, EventArgs e)
    {
        var requests = new List<AppIconReplaceRequest>();

        if (!string.IsNullOrWhiteSpace(TextBox_DiscordShortcut.Text) && !string.IsNullOrWhiteSpace(TextBox_DiscordIcon.Text))
            requests.Add(new AppIconReplaceRequest(TextBox_DiscordShortcut.Text, Path.GetFileName(TextBox_DiscordIcon.Text)));

        if (!string.IsNullOrWhiteSpace(TextBox_DiscordPTBShortcut.Text) && !string.IsNullOrWhiteSpace(TextBox_DiscordPTBIcon.Text))
            requests.Add(new AppIconReplaceRequest(TextBox_DiscordPTBShortcut.Text, Path.GetFileName(TextBox_DiscordPTBIcon.Text)));

        if (!string.IsNullOrWhiteSpace(TextBox_DiscordCanaryShortcut.Text) && !string.IsNullOrWhiteSpace(TextBox_DiscordCanaryIcon.Text))
            requests.Add(new AppIconReplaceRequest(TextBox_DiscordCanaryShortcut.Text, Path.GetFileName(TextBox_DiscordCanaryIcon.Text)));

        var replacer = new AppIconReplacer();
        var facade = new AppIconReplaceFacade(replacer);

        try
        {
            facade.ApplyAll(_defaultIconsFolder, requests);

            var appDirectories = requests.Select(r => r.TargetDir).ToList();
            var startMenuRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Microsoft", "Windows", "Start Menu");
            var shortcutRequests = new StartMenuShortcutLocator().BuildRequests(startMenuRoot, appDirectories);
            new ShortcutUpdateFacade(new ShortcutUpdater()).ApplyAll(shortcutRequests);

            if (CheckBox_RestartExplorer.Checked)
            {
                _systemService.RestartExplorer();
                MessageBox.Show("New Discord Icons applied successfully!\n\nExplorer restarted to refresh icons.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("New Discord Icons applied successfully!\n\nPlease restart Explorer manually if the icons don't auto-update in the Start Menu shortcuts.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void Button_Browse_DiscordShortcut_Click(object sender, EventArgs e)
    {
        var result = _fileDialogService.ShowFolderDialog("Select Discord App Folder", TextBox_DiscordShortcut.Text);
        if (result != null)
            TextBox_DiscordShortcut.Text = result;
    }

    private void Button_Browse_DiscordIcon_Click(object sender, EventArgs e)
    {
        var result = _fileDialogService.ShowFileDialog("Icon", "ico");
        if (result != null)
            TextBox_DiscordIcon.Text = result;
    }

    private void Button_Browse_DiscordPTBShortcut_Click(object sender, EventArgs e)
    {
        var result = _fileDialogService.ShowFolderDialog("Select Discord PTB App Folder", TextBox_DiscordPTBShortcut.Text);
        if (result != null)
            TextBox_DiscordPTBShortcut.Text = result;
    }

    private void Button_Browse_DiscordPTBIcon_Click(object sender, EventArgs e)
    {
        var result = _fileDialogService.ShowFileDialog("Icon", "ico");
        if (result != null)
            TextBox_DiscordPTBIcon.Text = result;
    }

    private void Button_Browse_DiscordCanaryShortcut_Click(object sender, EventArgs e)
    {
        var result = _fileDialogService.ShowFolderDialog("Select Discord Canary App Folder", TextBox_DiscordCanaryShortcut.Text);
        if (result != null)
            TextBox_DiscordCanaryShortcut.Text = result;
    }

    private void Button_Browse_DiscordCanaryIcon_Click(object sender, EventArgs e)
    {
        var result = _fileDialogService.ShowFileDialog("Icon", "ico");
        if (result != null)
            TextBox_DiscordCanaryIcon.Text = result;
    }

    private void Button_SaveSettings_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.DiscordShortcut = TextBox_DiscordShortcut.Text;
        Properties.Settings.Default.DiscordIcon = TextBox_DiscordIcon.Text;
        Properties.Settings.Default.DiscordPTBShortcut = TextBox_DiscordPTBShortcut.Text;
        Properties.Settings.Default.DiscordPTBIcon = TextBox_DiscordPTBIcon.Text;
        Properties.Settings.Default.DiscordCanaryShortcut = TextBox_DiscordCanaryShortcut.Text;
        Properties.Settings.Default.DiscordCanaryIcon = TextBox_DiscordCanaryIcon.Text;
        Properties.Settings.Default.RestartExplorerAfterApply = CheckBox_RestartExplorer.Checked;
        Properties.Settings.Default.Save();
    }

    private void Button_Close_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
