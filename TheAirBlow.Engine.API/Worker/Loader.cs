using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAirBlow.Engine.API.Binary;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API.Worker
{
    public static class Loader
    {
        internal static bool loaded = false;
        internal static string path = "";
        /*
        internal static ProjectJSON project = new ProjectJSON();
        internal static RoomsJSON rooms = new RoomsJSON();
        internal static SoundsJSON sounds = new SoundsJSON();
        internal static GameObjectsJSON objects = new GameObjectsJSON();
        */
        internal static BinaryData data = new BinaryData();
        internal static bool debug = false;
        
        public static void Load(string newPath, bool newDebug)
        {
            if (!loaded)
            {
                loaded = true;
                debug = newDebug;
                Logger.Log("[LOADER] Loading game's project...");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                path = newPath;
                Logger.path = path;

                //string[] dirs = { "\\Assets", "\\Assets\\Sprites", "\\Assets\\Sounds" };
                string[] dirs = new string[2];
                if (debug)
                {
                    dirs[0] = "\\Assets\\Sounds";
                    dirs[1] = "\\Assets\\Sprites";
                }
                else
                {
                    dirs[0] = "\\Sounds";
                    dirs[1] = "\\Sprites";
                }
                //string[] files = { "\\project.uep", "\\Assets\\sounds.ued",
                //"\\Assets\\objects.ued", "\\Assets\\rooms.ued" };
                string[] files = { "\\game.ueg" };

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
                    data = BinaryLoader.LoadBinary(File.ReadAllBytes(path + "\\game.ueg"));
                    /*
                    project = JsonConvert.DeserializeObject<ProjectJSON>(File.ReadAllText(path + files[0]));
                    rooms = JsonConvert.DeserializeObject<RoomsJSON>(File.ReadAllText(path + files[3]));
                    sounds = JsonConvert.DeserializeObject<SoundsJSON>(File.ReadAllText(path + files[1]));
                    objects = JsonConvert.DeserializeObject<GameObjectsJSON>(File.ReadAllText(path + files[2]));
                    */
                }
                catch (Exception e)
                {
                    Logger.LogException(new Exception($"Cound not load the game: {e.Message}", e));
                    throw new Exception($"Cound not load the game: {e.Message}", e);
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
            
            for (int i = 0; i < data.sounds.Count; i++)
            {
                if (data.sounds[i].name == name)
                    return data.sounds[i].path;
            }

            return null;
        }

        public static BinaryObject GetObjectByName(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < data.objects.Count; i++)
            {
                if (data.objects[i].name == name)
                    return data.objects[i];
            }

            return null;
        }

        public static BinaryRoom GetRoomByName(string name)
        {
            if (!loaded)
            {
                Logger.LogException(new Exception("Could not get something: Game is not loaded yet!"));
                throw new Exception("Could not get something: Game is not loaded yet!");
            }

            for (int i = 0; i < data.rooms.Count; i++)
            {
                if (data.rooms[i].name == name)
                    return data.rooms[i];
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

            for (int i = 0; i < data.sounds.Count; i++)
            {
                if (data.sounds[i].name == name)
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

            for (int i = 0; i < data.rooms.Count; i++)
            {
                if (data.rooms[i].name == name)
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

            for (int i = 0; i < data.objects.Count; i++)
            {
                if (data.objects[i].name == name)
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

            for (int i = 0; i < data.sounds.Count; i++)
            {
                if (data.sounds[i].name == name)
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

            for (int i = 0; i < data.rooms.Count; i++)
            {
                if (data.rooms[i].name == name)
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

            for (int i = 0; i < data.objects.Count; i++)
            {
                if (data.objects[i].name == name)
                    return i;
            }

            return -1;
        }
    }
}
