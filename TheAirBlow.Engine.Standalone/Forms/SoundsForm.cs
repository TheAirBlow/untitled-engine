using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.Engine.Standalone.Forms
{
    public partial class SoundsForm : Form
    {
        public SoundsForm()
        {
            InitializeComponent();
        }

        private string selectedSoundPath;
        private SoundPlayer player;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SoundsForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ProjectSaving.sounds.sounds.Count; i++)
            {
                string str = ProjectSaving.sounds.sounds[i].name;
                soundSelect.Items.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            if (ProjectSaving.InputBox("Untitled Engine", "Enter new sound's name:", ref name) != DialogResult.OK || name == "") return;
            if (ProjectSaving.HaveSound(name))
            {
                MessageBox.Show("That sound name is already used by another one.", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WAV|*.wav";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                try { File.Copy(path, ProjectSaving.path + "\\Assets\\Sounds\\" + Path.GetFileName(path), true); }
                catch
                {
                    MessageBox.Show($"Could not copy sound file to into Assets folder.", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Sound sound = new Sound();
                sound.name = name;
                sound.path = Path.GetFileName(path);
                ProjectSaving.sounds.sounds.Add(sound);
                soundSelect.Items.Add(name);
                selectedSoundPath = ProjectSaving.path + "\\Assets\\Sounds\\" + Path.GetFileName(path);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (soundSelect.SelectedIndex != -1)
            {
                int index = ProjectSaving.SoundIndex((string)soundSelect.SelectedItem);
                soundSelect.Items.RemoveAt(soundSelect.SelectedIndex);
                if (index != -1) ProjectSaving.sounds.sounds.RemoveAt(index);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = (string)soundSelect.SelectedItem;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WAV|*.wav";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                try { File.Copy(path, ProjectSaving.path + "\\Assets\\Sounds\\" + Path.GetFileName(path), true); }
                catch
                {
                    MessageBox.Show($"Could not copy sound file to into Assets folder.", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int index = ProjectSaving.SoundIndex(name);
                if (index != 1)
                {
                    ProjectSaving.sounds.sounds[index].path = Path.GetFileName(path);
                    selectedSoundPath = ProjectSaving.path + "\\Assets\\Sounds\\" + Path.GetFileName(path);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedSoundPath != "")
            {
                player = new SoundPlayer(selectedSoundPath);
                player.Play();
            }
        }

        private void soundSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)soundSelect.SelectedItem;
            string path = ProjectSaving.GetSoundPathByName(name);
            if (path != null)
            {
                selectedSoundPath = ProjectSaving.path + "\\Assets\\Sounds\\" + path;
                textBox1.Text = name;
            }
        }
    }
}
