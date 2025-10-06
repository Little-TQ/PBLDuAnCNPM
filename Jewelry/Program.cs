using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetProcessDPIAware();
<<<<<<< HEAD
            Application.Run(new HomePage());
=======
            Application.Run(new DashBoard());
>>>>>>> 570a598 (Quynh edit DashBoard)
        }
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
