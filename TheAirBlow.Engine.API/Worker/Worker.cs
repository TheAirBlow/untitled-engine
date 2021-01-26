using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAirBlow.Engine.API.Worker;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API
{
    public static class MainWorker
    {
        internal static bool loaded = false;
        internal static Room currentRoom;
        public static Graphics g;

        public static void StartWorker()
        {
            Logger.Log("[WORKER] Starting worker...");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (Loader.loaded)
            {
                if (!loaded)
                {
                    Logger.Log("[WORKER] Loading...");
                    loaded = true;
                    if (Loader.rooms.rooms[0] == null)
                    {
                        Logger.LogException(new Exception("Could not start worker: There is no rooms!"));
                        throw new Exception("Could not start worker: There is no rooms!");
                    }

                    currentRoom = Loader.rooms.rooms[0];

                    watch.Stop();
                    Logger.Log($"[WORKER] Starting done in {watch.Elapsed}!");
                }
                else
                {
                    Logger.LogException(new Exception("Could not start worker: It is already started!"));
                    throw new Exception("Could not start worker: It is already started!");
                }
            }
            else
            {
                Logger.LogException(new Exception("Could not start worker: Game is not loaded yet!"));
                throw new Exception("Could not start worker: Game is not loaded yet!");
            }
        }

        internal static void Step()
        {
            UpdateRoomView();
        }

        internal static void UpdateRoomView()
        {
            DrawObjects(currentRoom.gridSize, currentRoom.gridWidth, currentRoom.gridHeight);
        }

        internal static void DrawObjects(int size, int width, int height)
        {
            for (int forX = 0; forX < width; forX++)
            {
                for (int forY = 0; forY < height; forY++)
                {
                    for (int i = 0; i < currentRoom.roomObjects.Count; i++)
                    {
                        if (currentRoom.roomObjects[i].x != forX) continue;
                        if (currentRoom.roomObjects[i].y != forY) continue;
                        int posX = size * forX;
                        int posY = size * forY;
                        if (Loader.GetObjectByName(currentRoom.roomObjects[i].name) == null)
                        {
                            Logger.LogException(new Exception("Worker Error: Could not load the object: " +
                                $"{currentRoom.roomObjects[i].name}"));
                            throw new Exception("Worker Error: Could not load the object: " +
                                $"{currentRoom.roomObjects[i].name}");
                        }
                        g.DrawImage(Image.FromFile(Loader.path + "\\Assets\\Sprites\\"
                            + Loader.GetObjectByName(currentRoom.roomObjects[i].name).sprite), posX, posY);
                    }
                }
            }
        }
    }
}
