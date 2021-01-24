using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.Engine.Standalone.Forms
{
    public partial class ObjectsForm : Form
    {
        public ObjectsForm()
        {
            InitializeComponent();
        }

        private GameObject currentObject;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBox.Show($"Object is not selected yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG|*.png|JPG|.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                try { File.Copy(path, ProjectSaving.path + "\\Assets\\Sprites\\" + Path.GetFileName(path), true); }
                catch
                {
                    MessageBox.Show($"Could not copy sprite file to into Assets folder.", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentObject.sprite = Path.GetFileName(path);
                spriteIcon.Image = Image.FromFile(ProjectSaving.path + "\\Assets\\Sprites\\" + Path.GetFileName(path));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            if (ProjectSaving.InputBox("Untitled Engine", "Enter new object's name: ", ref name) == DialogResult.OK)
            {
                string code = @"public static void OnCreate() {
    // Code here will be run when the object is created
}

public static void OnStep() {
    // Code here will be run every step
}";

                GameObject obj = new GameObject();
                obj.name = name;
                obj.code = code;
                objectSelect.Items.Add(name);
                ProjectSaving.objects.objects.Add(obj);
                currentObject = obj;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = ProjectSaving.ObjectIndex((string)objectSelect.SelectedItem);
            if (index != -1)
            {
                objectSelect.Items.RemoveAt(objectSelect.SelectedIndex);
                ProjectSaving.objects.objects.RemoveAt(index);
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (currentObject == null) return;
            currentObject.name = nameBox.Text;
        }

        private void objectSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ProjectSaving.ObjectIndex((string)objectSelect.SelectedItem);
            if (index != -1)
            {
                currentObject = ProjectSaving.objects.objects[index];
                nameBox.Text = currentObject.name;
                richTextBox1.Text = currentObject.code;
                if (currentObject.sprite != "")
                    spriteIcon.Image = Image.FromFile(ProjectSaving.path + "\\Assets\\Sprites\\" + currentObject.sprite);
            }
        }

        private void messageBlock_Click(object sender, EventArgs e)
        {

        }

        private void ObjectsForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ProjectSaving.objects.objects.Count; i++)
            {
                objectSelect.Items.Add(ProjectSaving.objects.objects[i].name);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            currentObject.code = richTextBox1.Text;
        }
    }
}
