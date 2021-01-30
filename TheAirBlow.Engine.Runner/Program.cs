using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheAirBlow.Engine.API.Worker;

namespace TheAirBlow.Engine.Runner
{
    public static class Program
    {
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        [STAThread]
        public static void Main()
        {
            try
            {
                SetProcessDPIAware();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainRunner.Start(Directory.GetCurrentDirectory(), false);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    MessageBox.Show(e.Message +
                        $"\n\nInner Exception: {e.InnerException.Message}", "Untitled Engine Runner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(e.Message, "Untitled Engine Runner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
