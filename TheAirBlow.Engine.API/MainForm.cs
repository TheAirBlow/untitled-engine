using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheAirBlow.Engine.API.Worker;

namespace TheAirBlow.Engine.API
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs ev)
        {
            try
            {
                FormClosed += MainForm_OnClose;
                AutoScaleMode = AutoScaleMode.None;
                SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

                if (Loader.debug)
                    richTextBox1.Text = "RUNNING IN DEBUG MODE | CTRL + D" +
                        "\nFOR GAME DEVELOPMENT USE ONLY";

                if (Loader.project.splash)
                    await Task.Delay(3000);
                panel1.Visible = false;
                MainWorker.StartWorker();

                Logger.Log("[WORKER] Starting the game...");
                int totalWidth = MainWorker.currentRoom.gridSize * MainWorker.currentRoom.gridWidth;
                int totalHeight = MainWorker.currentRoom.gridSize * MainWorker.currentRoom.gridHeight;
                Size = new Size(totalWidth + 18, totalHeight + 48);
                BackColor = MainWorker.currentRoom.color;
                MainWorker.g = Loader.form.CreateGraphics();
                Logger.Log($"[WORKER] Entering game loop...");
                while (!IsDisposed)
                {
                    MainWorker.Step();
                    await Task.Delay(100);
                }
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

        private void MainForm_OnClose(object sender, EventArgs e)
        {
            Loader.loaded = false;
            Loader.path = null;
            Loader.project = null;
            Loader.rooms = null;
            Loader.sounds = null;
            Loader.objects = null;
            MainWorker.loaded = false;
            MainWorker.g = null;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
