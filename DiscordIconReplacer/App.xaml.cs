using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using DiscordIconReplacer.Skins;

namespace DiscordIconReplacer;

public partial class App : Application
{
    private readonly string _crashLog = Path.Combine(
        Path.GetTempPath(), "DiscordIconReplacer_crash.log");

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        DispatcherUnhandledException += (s, args) =>
        {
            File.AppendAllText(_crashLog, "[UI] " + DateTime.Now + "\n" + args.Exception + "\n");
            MessageBox.Show(
                $"An unexpected error occurred:\n\n{args.Exception.Message}",
                "Discord Icon Replacer",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            args.Handled = true;
        };
        AppDomain.CurrentDomain.UnhandledException += (s, args) =>
        {
            File.AppendAllText(_crashLog, "[Domain] " + DateTime.Now + "\n" + args.ExceptionObject + "\n");
        };

        string skin = DiscordIconReplacer.Properties.Settings.Default.SelectedSkin;
        if (string.IsNullOrWhiteSpace(skin))
            skin = "Main";

        SkinManager.ApplySkin(skin);
    }
}
