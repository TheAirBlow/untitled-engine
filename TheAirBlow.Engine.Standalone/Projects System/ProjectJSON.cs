using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAirBlow.Engine.Standalone
{
    public class ProjectJSON
    {
        public int intVer = Program.intVer;
        public string version = Program.version;
        public string name = "";
    }

    public class GameObjectsJSON
    {
        public List<GameObject> objects = new List<GameObject>();
    }

    public class SoundsJSON
    {
        public List<Sound> sounds = new List<Sound>();
    }

    public class Sound
    {
        public string name = "";
        public string path = "";
    }

    public class RoomsJSON
    {
        public List<Room> rooms = new List<Room>();
    }

    public class Room
    {
        public List<int> roomObjectsId = new List<int>();
        public int gridSize = 32;
        public int gridWidth = 8;
        public int gridHeight = 8;
    }

    public class GameObject
    {
        public int id = -1;
        public string name = "";
        public string sprite = "";

        // TODO: Events and blocks
    }
}
