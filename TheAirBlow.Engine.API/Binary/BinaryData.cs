using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API.Binary
{
    public class BinaryData
    {
        public List<BinaryRoom> rooms;
        public List<BinarySound> sounds;
        public List<BinaryObject> objects;
    }

    public class BinaryRoom
    {
        public int binaryLength;
        public string name;
        public Color color;
        public List<RoomObject> roomObjects;
        public int gridHeight;
        public int gridWidth;
        public int gridSize;
    }

    public class BinarySound
    {
        public int binaryLength;
        public string path;
        public string name;
    }

    public class BinaryObject
    {
        public int binaryLength;
        public byte[] spriteData;
        public string name;
        public string code;
    }
}
