using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.Engine.Standalone
{
    public static class ProjectSaving
    {
        public static string path = "";
        public static ProjectJSON project = new ProjectJSON();
        public static RoomsJSON rooms = new RoomsJSON();
        public static SoundsJSON sounds = new SoundsJSON();
        public static GameObjectsJSON objects = new GameObjectsJSON();

        public static bool SelectPathDialog()
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) path = folderBrowserDialog1.SelectedPath;
            else return false;

            return true;
        }

        public static void LoadProject()
        {
            if (path == "") if (!SelectPathDialog()) return;

            string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sprites" };
            string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

            foreach (string dir in dirs)
            {
                if (!Directory.Exists(path + dir))
                {
                    MessageBox.Show("Could not load this project." +
                        $"\nMissing directory: {dir.Remove(0, 2)}", "Untitled Engine", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            foreach (string file in files)
            {
                if (!File.Exists(path + file))
                {
                    MessageBox.Show("Could not load this project." +
                        $"\nMissing file: {file.Remove(0, 2)}", "Untitled Engine",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            project = JsonConvert.DeserializeObject<ProjectJSON>(path + File.ReadAllText(files[0]));
            rooms = JsonConvert.DeserializeObject<RoomsJSON>(path + File.ReadAllText(files[3]));
            sounds = JsonConvert.DeserializeObject<SoundsJSON>(path + File.ReadAllText(files[1]));
            objects = JsonConvert.DeserializeObject<GameObjectsJSON>(path + File.ReadAllText(files[2]));
        }

        public static void SaveProject()
        {
            if (path == "") if (!SelectPathDialog()) return;

            string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sprites" };
            string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

            foreach (string dir in dirs) Directory.CreateDirectory(path + dir);

            File.WriteAllText(path + files[0], JsonConvert.SerializeObject(project));
            File.WriteAllText(path + files[1], JsonConvert.SerializeObject(sounds));
            File.WriteAllText(path + files[2], JsonConvert.SerializeObject(objects));
            File.WriteAllText(path + files[3], JsonConvert.SerializeObject(rooms));
        }

        public static void NewProject()
        {
            string name = "";
            if (InputBox("Untitled Engine", "Enter new project's name:", ref name) != DialogResult.OK) return;
            if (name == "") return;

            if (!SelectPathDialog()) return;

            string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sprites" };
            string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

            foreach (string dir in dirs) Directory.CreateDirectory(path + dir);

            project = new ProjectJSON();
            sounds = new SoundsJSON();
            objects = new GameObjectsJSON();
            rooms = new RoomsJSON();

            File.WriteAllText(path + files[0], JsonConvert.SerializeObject(project));
            File.WriteAllText(path + files[1], JsonConvert.SerializeObject(sounds));
            File.WriteAllText(path + files[2], JsonConvert.SerializeObject(objects));
            File.WriteAllText(path + files[3], JsonConvert.SerializeObject(rooms));
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }

    /*
    This is how project folder should look:

    Project
      project.uep
      Assets
        Sprites
          [sprites]
        Sounds
          [sounds]
        sounds.ued
        objects.ued
        rooms.ued
    */
}
