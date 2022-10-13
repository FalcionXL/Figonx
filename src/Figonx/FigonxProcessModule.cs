using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figonx
{
    public class FigonxProcessModule
    {
        public string CollectProcessModules(string proc)
        {
            string collect_process = String.Empty;
            Process[] process = Process.GetProcessesByName(proc);
            foreach(Process klx12 in process)
            {
                ProcessModule mod = klx12.MainModule;
                string module = mod.FileName;
                string bx = mod.ModuleName;
                IntPtr size_mod = mod.BaseAddress;
                collect_process = $"File Name: {module}" + Environment.NewLine + $"Module Name: {bx}" + Environment.NewLine + $"Base Address: 0x{size_mod}";
            }
            return collect_process;
        }
        public void ProcessModuleRustClient()
        {
            if (Directory.Exists(@"C:\Temp"))
            {
                File.WriteAllText(@"C:\Temp\ProcModule.txt", CollectProcessModules("RustClient.exe"));
            }
            else
            {
                throw new Exception("Directory not Found or Process is not Launched");
            }
        }
    }
}
