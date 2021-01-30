using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheAirBlow.Engine.API.Worker;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API.Binary
{
    public static class BinaryLoader
    {
        public static BinaryData LoadBinary(byte[] bytes)
        {
            BinaryData data = new BinaryData();
            data.objects = new List<BinaryObject>();
            data.sounds = new List<BinarySound>();
            data.rooms = new List<BinaryRoom>();
            int cursor = 0;
            while (cursor != bytes.Length)
            {
                switch (bytes[cursor])
                {
                    case 0x00:
                        // Sound
                        cursor++;
                        BinarySound sound = LoadSound(bytes, cursor);
                        cursor += sound.binaryLength;
                        data.sounds.Add(sound);
                        break;
                    case 0xAA:
                        // Room
                        cursor++;
                        BinaryRoom room = LoadRoom(bytes, cursor);
                        cursor += room.binaryLength;
                        data.rooms.Add(room);
                        break;
                    case 0xFF:
                        // Object
                        cursor++;
                        BinaryObject obj = LoadObject(bytes, cursor);
                        cursor += obj.binaryLength;
                        data.objects.Add(obj);
                        break;
                    default:
                        Logger.LogException(new Exception($"Could not load game's binary: Unknown type (byte {bytes[cursor]}, cursor {cursor})"));
                        throw new Exception($"Could not load game's binary: Unknown type (byte {bytes[cursor]}, cursor {cursor})");
                }
            }

            return data;
        }

        private static BinarySound LoadSound(byte[] bytes, int offset)
        {
            int originalOffset = offset;
            BinarySound sound = new BinarySound();
            int length = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            byte[] nameBytes = new byte[length];
            for (int i = offset; i < (length + offset); i++)
                nameBytes[i - offset] += bytes[i];
            sound.name = Encoding.ASCII.GetString(nameBytes);
            offset += length;

            length = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            byte[] dataBytes = new byte[length];
            for (int i = offset; i < (length + offset); i++)
                dataBytes[i - offset] += bytes[i];
            sound.path = Encoding.ASCII.GetString(dataBytes);
            offset += length;

            sound.binaryLength = offset - originalOffset;
            return sound;
        }

        private static BinaryObject LoadObject(byte[] bytes, int offset)
        {
            int originalOffset = offset;
            BinaryObject obj = new BinaryObject();
            int length = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            byte[] nameBytes = new byte[length];
            for (int i = offset; i < (length + offset); i++)
                nameBytes[i - offset] += bytes[i];
            obj.name = Encoding.ASCII.GetString(nameBytes);
            offset += length;

            length = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            byte[] codeBytes = new byte[length];
            for (int i = offset; i < (length + offset); i++)
                codeBytes[i - offset] += bytes[i];
            obj.code = Encoding.ASCII.GetString(codeBytes);
            offset += length;

            length = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            byte[] dataBytes = new byte[length];
            for (int i = offset; i < length; i++)
                dataBytes[i - offset] += bytes[i];
            obj.spriteData = dataBytes;
            offset += length;

            obj.binaryLength = offset - originalOffset;
            return obj;
        }

        private static BinaryRoom LoadRoom(byte[] bytes, int offset)
        {
            int originalOffset = offset;
            BinaryRoom room = new BinaryRoom();
            room.roomObjects = new List<RoomObject>();
            int length = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            byte[] nameBytes = new byte[length];
            for (int i = offset; i < (length + offset); i++)
                nameBytes[i - offset] += bytes[i];
            room.name = Encoding.ASCII.GetString(nameBytes);
            offset += length;

            room.color = Color.FromArgb(255, bytes[offset], bytes[offset + 1], bytes[offset + 2]);
            offset += 3;

            room.gridSize = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            room.gridWidth = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            room.gridHeight = BitConverter.ToInt32(bytes, offset);
            offset += 4;

            int count = BitConverter.ToInt32(bytes, offset);
            offset += 4;
            int objects = 1;
            while (objects <= count)
            {
                length = BitConverter.ToInt32(bytes, offset);
                offset += 4;
                RoomObject obj = new RoomObject();
                nameBytes = new byte[length];
                for (int i = offset; i < (length + offset); i++)
                    nameBytes[i - offset] += bytes[i];
                obj.name = Encoding.ASCII.GetString(nameBytes);
                offset += length;

                obj.x = BitConverter.ToInt32(bytes, offset);
                offset += 4;
                obj.y = BitConverter.ToInt32(bytes, offset);
                offset += 4;

                room.roomObjects.Add(obj);
                objects++;
            }

            room.binaryLength = offset - originalOffset;
            return room;
        }
    }
}
