using System;
using System.Diagnostics;

namespace DiscordIconReplacer.SystemServices;

public class SystemService
{
    public void RestartExplorer()
    {
        foreach (var process in Process.GetProcessesByName("explorer"))
        {
            try
            {
                if (process.HasExited)
                    continue;

                process.Kill();
                process.WaitForExit();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Failed to terminate explorer process: {ex.Message}");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Debug.WriteLine($"Failed to terminate explorer process: {ex.Message}");
            }
            finally
            {
                process.Dispose();
            }
        }

        try
        {
            using (Process.Start("explorer.exe"))
            {
            }
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            Debug.WriteLine($"Failed to restart explorer: {ex.Message}");
        }
    }
}
