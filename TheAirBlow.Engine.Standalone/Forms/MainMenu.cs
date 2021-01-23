using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void runButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In development!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In development!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new AboutForm().Show();
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            ProjectSaving.NewProject();
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
            ProjectSaving.LoadProject();
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

        }
    }
}
