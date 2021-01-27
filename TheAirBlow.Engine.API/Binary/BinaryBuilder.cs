using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API.Binary
{
    public static class BinaryBuilder
    {
        public static byte[] BuildBinary(string assets, bool splash, RoomsJSON rooms, SoundsJSON sounds, GameObjectsJSON objects)
        {
            try
            {
                List<byte> bytes = new List<byte>();
                Action<byte> add = new Action<byte>((obj) => { bytes.Add(obj); });

                // Splash byte
                if (splash) add(0xFF);
                else add(0x00);

                // Sounds (Byte 0x00)
                foreach (Sound sound in sounds.sounds)
                {
                    // Asset type byte
                    add(0x00);

                    // Asset name
                    byte[] assetNameBytes = Encoding.ASCII.GetBytes(sound.name);
                    byte[] assetNameLength = BitConverter.GetBytes(assetNameBytes.Length);
                    foreach (byte Byte in assetNameBytes) add(Byte);
                    foreach (byte Byte in assetNameLength) add(Byte);

                    // Sound's data
                    byte[] soundBytes = File.ReadAllBytes(assets + "Sounds\\" + sound.path);
                    byte[] soundLength = BitConverter.GetBytes(soundBytes.Length);
                    foreach (byte Byte in soundLength) add(Byte);
                    foreach (byte Byte in soundBytes) add(Byte);
                }

                // Rooms (Byte 0xAA)
                foreach (Room room in rooms.rooms)
                {
                    // Asset type byte
                    add(0xAA);

                    // Asset name
                    byte[] assetNameBytes = Encoding.ASCII.GetBytes(room.name);
                    byte[] assetNameLength = BitConverter.GetBytes(assetNameBytes.Length);
                    foreach (byte Byte in assetNameLength) add(Byte);
                    foreach (byte Byte in assetNameBytes) add(Byte);

                    // Grid Size
                    byte[] roomCellSize = BitConverter.GetBytes(room.gridSize);
                    foreach (byte Byte in roomCellSize) add(Byte);

                    // Grid Width
                    byte[] roomCellWidth = BitConverter.GetBytes(room.gridWidth);
                    foreach (byte Byte in roomCellWidth) add(Byte);

                    // Grid Height
                    byte[] roomCellHeight = BitConverter.GetBytes(room.gridHeight);
                    foreach (byte Byte in roomCellHeight) add(Byte);

                    // Room Objects
                    foreach (RoomObject obj in room.roomObjects)
                    {
                        // Object's name
                        byte[] objectNameBytes = Encoding.ASCII.GetBytes(obj.name);
                        byte[] objectNameLength = BitConverter.GetBytes(objectNameBytes.Length);
                        foreach (byte Byte in objectNameLength) add(Byte);
                        foreach (byte Byte in objectNameBytes) add(Byte);

                        // Grid X
                        byte[] objectGridX = BitConverter.GetBytes(obj.x);
                        foreach (byte Byte in objectGridX) add(Byte);

                        // Grid Y
                        byte[] objectGridY = BitConverter.GetBytes(obj.y);
                        foreach (byte Byte in objectGridY) add(Byte);
                    }
                }

                // Objects (Byte 0xFF)
                foreach (GameObject obj in objects.objects)
                {
                    add(0xFF);

                    // Asset name
                    byte[] assetNameBytes = Encoding.ASCII.GetBytes(obj.name);
                    byte[] assetNameLength = BitConverter.GetBytes(assetNameBytes.Length);
                    foreach (byte Byte in assetNameLength) add(Byte);
                    foreach (byte Byte in assetNameBytes) add(Byte);

                    // Sprite's data
                    byte[] spriteBytes = File.ReadAllBytes(assets + "Sprites\\" + obj.sprite);
                    byte[] spriteLength = BitConverter.GetBytes(spriteBytes.Length);
                    foreach (byte Byte in spriteLength) add(Byte);
                    foreach (byte Byte in spriteBytes) add(Byte);

                    // Object's code
                    byte[] codeBytes = Encoding.ASCII.GetBytes(obj.code);
                    byte[] codeLength = BitConverter.GetBytes(spriteBytes.Length);
                    foreach (byte Byte in codeLength) add(Byte);
                    foreach (byte Byte in codeBytes) add(Byte);
                }

                return bytes.ToArray();
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    MessageBox.Show("ERROR: Failed to build game's binary. " +
                        $"\nException: {e}", "Binary Builder");
                else
                    MessageBox.Show("ERROR: Failed to build game's binary. " +
                        $"\nException: {e}" +
                        $"\nSub Exception: {e.InnerException}", "Binary Builder");
                return null;
            }
        }
    }
}
