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
        public static bool dirtyBit = false;
        private static ProjectJSON _project = new ProjectJSON();
        public static ProjectJSON project { 
            get { dirtyBit = true; return _project; } 
            set { dirtyBit = true; _project = value; } 
        }
        private static RoomsJSON _rooms = new RoomsJSON();
        public static RoomsJSON rooms {
            get { dirtyBit = true; return _rooms; }
            set { dirtyBit = true; _rooms = value; }
        }
        private static SoundsJSON _sounds = new SoundsJSON();
        public static SoundsJSON sounds
        {
            get { dirtyBit = true; return _sounds; }
            set { dirtyBit = true; _sounds = value; }
        }
        private static GameObjectsJSON _objects = new GameObjectsJSON();
        public static GameObjectsJSON objects
        {
            get { dirtyBit = true; return _objects; }
            set { dirtyBit = true; _objects = value; }
        }

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
            if (!SelectPathDialog()) return;

            string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sounds" };
            string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

            foreach (string dir in dirs)
            {
                if (!Directory.Exists(path + dir))
                {
                    MessageBox.Show("Could not load this project." +
                        $"\nMissing directory: {dir.Remove(0, 1)}", "Untitled Engine", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (string file in files)
            {
                if (!File.Exists(path + file))
                {
                    MessageBox.Show("Could not load this project." +
                        $"\nMissing file: {file.Remove(0, 1)}", "Untitled Engine",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                ProjectJSON loadProject = JsonConvert.DeserializeObject<ProjectJSON>(File.ReadAllText(path + files[0]));

                if (loadProject.version != Program.version)
                {
                    if (loadProject.intVer < Program.intVer)
                    {
                        DialogResult result = MessageBox.Show("This project was created with older version of the Untitled Engine." +
                        "\nProject's engine version will be changed and you will not be able to load it in old engine version ever again." +
                        "\n\nDo you want to proceed?",
                        "Untitled Engine", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result != DialogResult.Yes)
                        {
                            path = "";
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, but we can't load this project." +
                            "\nIt was created in newer engine version and it probably have some changes to projects that this version won't recognize.",
                            "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        path = "";
                        return;
                    }
                }

                project = JsonConvert.DeserializeObject<ProjectJSON>(File.ReadAllText(path + files[0]));
                rooms = JsonConvert.DeserializeObject<RoomsJSON>(File.ReadAllText(path + files[3]));
                sounds = JsonConvert.DeserializeObject<SoundsJSON>(File.ReadAllText(path + files[1]));
                objects = JsonConvert.DeserializeObject<GameObjectsJSON>(File.ReadAllText(path + files[2]));

                Program.menu.Text = $"Untitled Engine | {project.name}";
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured while loading this project." +
                            "\nThis problem can occur when project's engine version is newer than this one." +
                            "\nHere is some debug info:" +
                            $"\n{e}",
                            "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                path = "";
            }
        }

        public static void LoadProject(string path)
        {
            string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sounds" };
            string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

            foreach (string dir in dirs)
            {
                if (!Directory.Exists(path + dir))
                {
                    MessageBox.Show("Could not load this project." +
                        $"\nMissing directory: {dir.Remove(0, 1)}", "Untitled Engine",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }

            foreach (string file in files)
            {
                if (!File.Exists(path + file))
                {
                    MessageBox.Show("Could not load this project." +
                        $"\nMissing file: {file.Remove(0, 1)}", "Untitled Engine",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }

            try
            {
                ProjectJSON loadProject = JsonConvert.DeserializeObject<ProjectJSON>(File.ReadAllText(path + files[0]));

                if (loadProject.version != Program.version)
                {
                    if (loadProject.intVer < Program.intVer)
                    {
                        DialogResult result = MessageBox.Show("This project was created with older version of the Untitled Engine." +
                        "\nProject's engine version will be changed and you will not be able to load it in old engine version ever again." +
                        "\n\nDo you want to proceed?",
                        "Untitled Engine", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result != DialogResult.Yes) Environment.Exit(0);
                    }
                    else
                    {
                        MessageBox.Show("Sorry, but we can't load this project." +
                            "\nIt was created in newer engine version and it probably have some changes to projects that this version won't recognize.",
                            "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }

                project = JsonConvert.DeserializeObject<ProjectJSON>(File.ReadAllText(path + files[0]));
                rooms = JsonConvert.DeserializeObject<RoomsJSON>(File.ReadAllText(path + files[3]));
                sounds = JsonConvert.DeserializeObject<SoundsJSON>(File.ReadAllText(path + files[1]));
                objects = JsonConvert.DeserializeObject<GameObjectsJSON>(File.ReadAllText(path + files[2]));

                Program.menu.Text = $"Untitled Engine | {project.name}";
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured while loading this project." +
                            "\nThis problem can occur when project's engine version is newer than this one." +
                            "\nHere is some debug info:" +
                            $"\n{e}",
                            "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        public static void SaveProject()
        {
            if (path == "")
            {
                MessageBox.Show("No project is loaded or created yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sounds" };
            string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

            foreach (string dir in dirs) Directory.CreateDirectory(path + dir);

            File.WriteAllText(path + files[0], JsonConvert.SerializeObject(project));
            File.WriteAllText(path + files[1], JsonConvert.SerializeObject(sounds));
            File.WriteAllText(path + files[2], JsonConvert.SerializeObject(objects));
            File.WriteAllText(path + files[3], JsonConvert.SerializeObject(rooms));

            Program.menu.Text = $"Untitled Engine | {project.name}";
            dirtyBit = false;
        }

        public static void NewProject()
        {
            string name = "";
            if (InputBox("Untitled Engine", "Enter new project's name:", ref name) != DialogResult.OK) return;
            if (name == "") return;

            if (!SelectPathDialog()) return;

            string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sounds" };
            string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

            foreach (string dir in dirs) Directory.CreateDirectory(path + dir);

            project = new ProjectJSON();
            sounds = new SoundsJSON();
            objects = new GameObjectsJSON();
            rooms = new RoomsJSON();

            project.name = name;

            File.WriteAllText(path + files[0], JsonConvert.SerializeObject(project));
            File.WriteAllText(path + files[1], JsonConvert.SerializeObject(sounds));
            File.WriteAllText(path + files[2], JsonConvert.SerializeObject(objects));
            File.WriteAllText(path + files[3], JsonConvert.SerializeObject(rooms));

            Program.menu.Text = $"Untitled Engine | {project.name}";
        }

        public static string GetSoundPathByName(string name)
        {
            for (int i = 0; i < sounds.sounds.Count; i++)
            {
                if (sounds.sounds[i].name == name)
                    return sounds.sounds[i].path;
            }

            return null;
        }

        public static GameObject GetObjectByName(string name)
        {
            for (int i = 0; i < objects.objects.Count; i++)
            {
                if (objects.objects[i].name == name)
                    return objects.objects[i];
            }

            return null;
        }

        public static Room GetRoomByName(string name)
        {
            for (int i = 0; i < rooms.rooms.Count; i++)
            {
                if (rooms.rooms[i].name == name)
                    return rooms.rooms[i];
            }

            return null;
        }

        public static bool HaveSound(string name)
        {
            for (int i = 0; i < sounds.sounds.Count; i++)
            {
                if (sounds.sounds[i].name == name)
                    return true;
            }

            return false;
        }

        public static bool HaveRoom(string name)
        {
            for (int i = 0; i < rooms.rooms.Count; i++)
            {
                if (rooms.rooms[i].name == name)
                    return true;
            }

            return false;
        }

        public static bool HaveObject(string name)
        {
            for (int i = 0; i < objects.objects.Count; i++)
            {
                if (objects.objects[i].name == name)
                    return true;
            }

            return false;
        }

        public static int SoundIndex(string name)
        {
            for (int i = 0; i < sounds.sounds.Count; i++)
            {
                if (sounds.sounds[i].name == name)
                    return i;
            }

            return -1;
        }

        public static int RoomIndex(string name)
        {
            for (int i = 0; i < rooms.rooms.Count; i++)
            {
                if (rooms.rooms[i].name == name)
                    return i;
            }

            return -1;
        }

        public static int ObjectIndex(string name)
        {
            for (int i = 0; i < objects.objects.Count; i++)
            {
                if (objects.objects[i].name == name)
                    return i;
            }

            return -1;
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.AutoScaleMode = AutoScaleMode.None;

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 40, 372, 20);
            buttonOk.SetBounds(210, 72, 80, 28);
            buttonCancel.SetBounds(300, 72, 80, 28);

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
