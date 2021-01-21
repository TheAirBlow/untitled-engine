using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAirBlow.Engine.Standalone
{
    public class ProjectJSON
    {
        public string version { get; set; }
        public string name { get; set; }
    }

    public class GameObjectsJSON
    {
        public List<GameObject> objects { get; set; }
    }

    public class SoundsJSON
    {
        public List<Sound> sounds { get; set; }
    }

    public class Sound
    {
        public string name { get; set; }
        public string path { get; set; }
    }

    public class RoomsJSON
    {
        public List<Room> rooms { get; set; }
    }

    public class Room
    {
        public List<int> roomObjectsId { get; set; }
        public int gridSize { get; set; }
        public int gridWidth { get; set; }
        public int gridHeight { get; set; }
    }

    public class GameObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sprite { get; set; }

        // TODO: Events
    }
}
