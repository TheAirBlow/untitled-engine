using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.Engine.Standalone.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            pictureBox2.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox2.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
        }

        private Point MouseDownLocation;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox2.Left = e.X + pictureBox2.Left - MouseDownLocation.X;
                pictureBox2.Top = e.Y + pictureBox2.Top - MouseDownLocation.Y;
            }
        }
    }
}
