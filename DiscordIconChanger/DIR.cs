using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordIconReplacer.Factories;
using DiscordIconReplacer.Facades;
using DiscordIconReplacer.Services;
using DiscordIconReplacer.Models;
using DiscordIconReplacer.SystemServices;
using System.IO;

namespace DiscordIconReplacer
{
    public partial class DIR : Form
    {
        public DIR(IFileDialogService fileDialogService, ISystemService systemService)
        {
            InitializeComponent();
            _fileDialogService = fileDialogService;
            _systemService = systemService;

            // Set the default paths for Discord Apps Data
            string discordAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Discord");
            string discordPTBAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DiscordPTB");
            string discordCanaryAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DiscordCanary");

            // Set the default icon paths based on the directory where the executable is located
            string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string defaultIconsFolder = Path.Combine(executableDirectory, "Icons");

            // Set the default option for the checkbox
            CheckBox_RestartExplorer.Checked = Properties.Settings.Default.RestartExplorerAfterApply;

            // Set the text boxes to default values if they are empty
            TextBox_DiscordShortcut.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordShortcut)
                ? discordAppDataPath
                : Properties.Settings.Default.DiscordShortcut;

            TextBox_DiscordIcon.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordIcon)
                ? Path.Combine(defaultIconsFolder, "burble_light.ico")
                : Properties.Settings.Default.DiscordIcon;

            TextBox_DiscordPTBShortcut.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordPTBShortcut)
                ? discordPTBAppDataPath
                : Properties.Settings.Default.DiscordPTBShortcut;

            TextBox_DiscordPTBIcon.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordPTBIcon)
                ? Path.Combine(defaultIconsFolder, "sherbet_dreamsicle.ico")
                : Properties.Settings.Default.DiscordPTBIcon;

            TextBox_DiscordCanaryShortcut.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordCanaryShortcut)
                ? discordCanaryAppDataPath
                : Properties.Settings.Default.DiscordCanaryShortcut;

            TextBox_DiscordCanaryIcon.Text = string.IsNullOrWhiteSpace(Properties.Settings.Default.DiscordCanaryIcon)
                ? Path.Combine(defaultIconsFolder, "sakura.ico")
                : Properties.Settings.Default.DiscordCanaryIcon;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private readonly IFileDialogService _fileDialogService;
        private readonly ISystemService _systemService;

        private void Button_ApplyIcons_Click(object sender, EventArgs e)
        {
            // Get the base path for the "Icons" folder located in the same directory as the executable
            string baseIconFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons");

            var requests = new List<AppIconReplaceRequest>();

            // Add a request for each non-empty Discord folder and corresponding icon
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
                // Apply all icon replacements
                facade.ApplyAll(baseIconFolder, requests);
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
            _fileDialogService.ShowFolderDialog(TextBox_DiscordShortcut, "Select Discord App Folder");
        }

        private void Button_Browse_DiscordIcon_Click(object sender, EventArgs e)
        {
            _fileDialogService.ShowFileDialog(TextBox_DiscordIcon, "Icon", "ico");
        }

        private void Button_Browse_DiscordPTBShortcut_Click(object sender, EventArgs e)
        {
            _fileDialogService.ShowFolderDialog(TextBox_DiscordShortcut, "Select Discord App Folder");
        }

        private void Button_Browse_DiscordPTBIcon_Click(object sender, EventArgs e)
        {
            _fileDialogService.ShowFileDialog(TextBox_DiscordPTBIcon, "Icon", "ico");
        }

        private void Button_Browse_DiscordCanaryShortcut_Click(object sender, EventArgs e)
        {
            _fileDialogService.ShowFolderDialog(TextBox_DiscordShortcut, "Select Discord App Folder");
        }

        private void Button_Browse_DiscordCanaryIcon_Click(object sender, EventArgs e)
        {
            _fileDialogService.ShowFileDialog(TextBox_DiscordCanaryIcon, "Icon", "ico");
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
}