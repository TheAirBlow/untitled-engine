using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAirBlow.Engine.Standalone
{
    public class ProjectJSON
    {
        public int intVer = 0;
        public string version = "1.0.0a";
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
        public Color color = Color.White;
        public string name = "";
        public List<RoomObject> roomObjects = new List<RoomObject>();
        public int gridSize = 64;
        public int gridWidth = 8;
        public int gridHeight = 8;
    }

    public class RoomObject
    {
        public string name = "";
        public int x = 0;
        public int y = 0;
    }

    public class GameObject
    {
        public string name = "";
        public string sprite = "";
        public string code = @"";
    }
}
