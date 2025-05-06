using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordIconReplacer.SystemServices
{
    public class SystemService : ISystemService
    {
        public void RestartExplorer()
        {
            foreach(var process in Process.GetProcessesByName("explorer"))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit();
                }
                catch { }
            }

            Process.Start("explorer.exe");
        }
    }
}
