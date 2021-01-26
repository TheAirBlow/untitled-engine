using System;
using System.Collections.Generic;
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
                MainRunner.Start();
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    MessageBox.Show(e.Message +
                        $"\nSub exception: {e.InnerException}", "Untitled Engine Runner");
                else
                    MessageBox.Show(e.Message, "Untitled Engine Runner");
            }
        }
    }
}
