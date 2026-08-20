using System;
using System.Diagnostics;

namespace DiscordIconReplacer.SystemServices;

public class SystemService : ISystemService
{
    public void RestartExplorer()
    {
        foreach (var process in Process.GetProcessesByName("explorer"))
        {
            try
            {
                process.Kill();
                process.WaitForExit();
            }
            catch (InvalidOperationException)
            {
            }
        }

        Process.Start("explorer.exe");
    }
}
