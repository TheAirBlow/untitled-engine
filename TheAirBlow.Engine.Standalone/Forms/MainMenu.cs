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

        private void objectsButton_Click(object sender, EventArgs e)
        {
            Form form = new ObjectsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void roomsButton_Click(object sender, EventArgs e)
        {
            Form form = new RoomsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void soundsButton_Click(object sender, EventArgs e)
        {
            Form form = new SoundsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void runButton_Click(object sender, EventArgs e)
        {

        }

        private void compileButton_Click(object sender, EventArgs e)
        {

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
    }
}
