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

        private async void MainForm_Load(object sender, EventArgs e)
        {
            AutoScaleMode = AutoScaleMode.None;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

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
            while (true)
            {
                MainWorker.Step();
                await Task.Delay(100);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
