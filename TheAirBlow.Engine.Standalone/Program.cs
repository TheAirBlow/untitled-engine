﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.Engine.Standalone
{
    public static class Program
    {
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
        public static MainMenu menu;
        public const string version = "1.0.0a";
        public const int intVer = 1;

        [STAThread]
        public static void Main(string[] args)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\runner.exe"))
            {
                MessageBox.Show($"ERROR: Could not find required file \"runner.exe\"",
                    "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path = "";
            foreach (string str in args) path += str;

            if (path != "")
                ProjectSaving.LoadProject(path);

            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            menu = new MainMenu();
            Application.Run(menu);
        }
    }
}
