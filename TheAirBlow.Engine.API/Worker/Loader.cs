using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API.Worker
{
    public static class Loader
    {
        internal static bool loaded = false;
        internal static string path = "";
        internal static ProjectJSON project = new ProjectJSON();
        internal static RoomsJSON rooms = new RoomsJSON();
        internal static SoundsJSON sounds = new SoundsJSON();
        internal static GameObjectsJSON objects = new GameObjectsJSON();
        public static MainForm form = new MainForm();
        
        public static void Load(string newPath)
        {
            if (!loaded)
            {
                loaded = true;
                Logger.Log("[LOADER] Loading game's project...");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                path = newPath;
                Logger.path = path;

                string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sounds" };
                string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                "\\Assets\\objects.ued", "\\Assets\\rooms.ued" };

                foreach (string dir in dirs)
                    if (!Directory.Exists(path + dir))
                    {
                        Logger.LogException(new Exception($"Cound not load the game: Missing directory: {dir.Remove(0, 1)}"));
                        throw new Exception($"Cound not load the game: Missing directory: {dir.Remove(0, 1)}");
                    }

                foreach (string file in files)
                    if (!File.Exists(path + file))
                    {
                        Logger.LogException(new Exception($"Cound not load the game: Missing file: {file.Remove(0, 1)}"));
                        throw new Exception($"Cound not load the game: Missing file: {file.Remove(0, 1)}");
                    }

                try
                {
                    project = JsonConvert.DeserializeObject<ProjectJSON>(File.ReadAllText(path + files[0]));
                    rooms = JsonConvert.DeserializeObject<RoomsJSON>(File.ReadAllText(path + files[3]));
                    sounds = JsonConvert.DeserializeObject<SoundsJSON>(File.ReadAllText(path + files[1]));
                    objects = JsonConvert.DeserializeObject<GameObjectsJSON>(File.ReadAllText(path + files[2]));
                }
                catch (Exception e)
                {
                    Logger.LogException(new Exception($"Cound not load the game: An error occured.", e));
                    throw new Exception($"Cound not load the game: An error occured.", e);
                }

                watch.Stop();
                Logger.Log($"[LOADER] Loaded in {watch.Elapsed}!");
            }
            else
            {
                Logger.LogException(new Exception("Cound not load the game: Game was already loaded!"));
                throw new Exception("Cound not load the game: Game was already loaded!");
            }
        }

        public static string GetSoundPathByName(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }
            
            for (int i = 0; i < sounds.sounds.Count; i++)
            {
                if (sounds.sounds[i].name == name)
                    return sounds.sounds[i].path;
            }

            return null;
        }

        public static GameObject GetObjectByName(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < objects.objects.Count; i++)
            {
                if (objects.objects[i].name == name)
                    return objects.objects[i];
            }

            return null;
        }

        public static Room GetRoomByName(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < rooms.rooms.Count; i++)
            {
                if (rooms.rooms[i].name == name)
                    return rooms.rooms[i];
            }

            return null;
        }

        public static bool HaveSound(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < sounds.sounds.Count; i++)
            {
                if (sounds.sounds[i].name == name)
                    return true;
            }

            return false;
        }

        public static bool HaveRoom(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < rooms.rooms.Count; i++)
            {
                if (rooms.rooms[i].name == name)
                    return true;
            }

            return false;
        }

        public static bool HaveObject(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < objects.objects.Count; i++)
            {
                if (objects.objects[i].name == name)
                    return true;
            }

            return false;
        }

        public static int SoundIndex(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < sounds.sounds.Count; i++)
            {
                if (sounds.sounds[i].name == name)
                    return i;
            }

            return -1;
        }

        public static int RoomIndex(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < rooms.rooms.Count; i++)
            {
                if (rooms.rooms[i].name == name)
                    return i;
            }

            return -1;
        }

        public static int ObjectIndex(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < objects.objects.Count; i++)
            {
                if (objects.objects[i].name == name)
                    return i;
            }

            return -1;
        }
    }
}
