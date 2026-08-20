using System;
using System.Windows.Forms;
using DiscordIconReplacer.Services;
using DiscordIconReplacer.SystemServices;

namespace DiscordIconReplacer;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm(new FileDialogService(), new SystemService()));
    }
}
