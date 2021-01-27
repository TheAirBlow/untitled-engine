using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheAirBlow.Engine.API.Binary;
using TheAirBlow.Engine.API.Worker;
using TheAirBlow.Engine.Standalone.Forms;

namespace TheAirBlow.Engine.Standalone
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public static bool scrolling = false;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (ProjectSaving.dirtyBit)
            {
                var result = MessageBox.Show("Do you want to save the project?", "Untitled Engine",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ProjectSaving.SaveProject();
                }
                else if (result == DialogResult.Cancel) e.Cancel = true;
            }
        }

        private void objectsButton_Click(object sender, EventArgs e)
        {
            if (ProjectSaving.path == "")
            {
                MessageBox.Show("Project is not created or loaded yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Text = $"Untitled Engine | {ProjectSaving.project.name}*";
            Form form = new ObjectsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void roomsButton_Click(object sender, EventArgs e)
        {
            if (ProjectSaving.path == "")
            {
                MessageBox.Show("Project is not created or loaded yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Text = $"Untitled Engine | {ProjectSaving.project.name}*";
            Form form = new RoomsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void soundsButton_Click(object sender, EventArgs e)
        {
            if (ProjectSaving.path == "")
            {
                MessageBox.Show("Project is not created or loaded yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Text = $"Untitled Engine | {ProjectSaving.project.name}*";
            Form form = new SoundsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void runButton_Click(object sender, EventArgs ev)
        {
            if (ProjectSaving.path == "")
            {
                MessageBox.Show("Project is not created or loaded yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProjectSaving.SaveProject();

            new Thread(() => {
                try { MainRunner.Start(ProjectSaving.path, true); }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                        MessageBox.Show(e.Message +
                            $"\nSub exception: {e.InnerException}", "Untitled Engine Runner");
                    else
                        MessageBox.Show(e.Message, "Untitled Engine Runner");
                }
            }).Start();
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            if (ProjectSaving.path == "")
            {
                MessageBox.Show("Project is not created or loaded yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string path;
            var folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) path = folderBrowserDialog1.SelectedPath;
            else return;

            ProjectSaving.SaveProject();

            File.Copy(Directory.GetCurrentDirectory() + "\\runner.exe", path + "\\runner.exe", true);
            Process proc = new Process();
            proc.StartInfo.FileName = path + "\\runner.exe";
            proc.Start();
            proc.WaitForExit();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new AboutForm().Show();
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            ProjectSaving.NewProject();
            checkBox1.Checked = ProjectSaving.project.splash;
            ProjectSaving.dirtyBit = false;
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
            ProjectSaving.LoadProject();
            checkBox1.Checked = ProjectSaving.project.splash;
            ProjectSaving.dirtyBit = false;
        }

        private void saveProjectButton_Click(object sender, EventArgs e)
        {
            ProjectSaving.SaveProject();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = ProjectSaving.project.splash;
            ProjectSaving.dirtyBit = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ProjectSaving.project.splash = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProjectSaving.path == "")
            {
                MessageBox.Show("Project is not created or loaded yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] bytes = BinaryBuilder.BuildBinary(ProjectSaving.path + "\\Assets\\", ProjectSaving.project.splash,
                ProjectSaving.rooms, ProjectSaving.sounds, ProjectSaving.objects);

            File.WriteAllBytes(ProjectSaving.path + "\\game.ueg", bytes);
        }
    }
}
