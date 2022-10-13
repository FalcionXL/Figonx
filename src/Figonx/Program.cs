using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figonx
{
    static class Program
    {
        /// <summary>
        /// Entry Point to Launch Form Figonx :D
        /// </summary>
        [MTAThread] //MultiThread :D
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FigonxAntiCheat());
        }
    }
}
