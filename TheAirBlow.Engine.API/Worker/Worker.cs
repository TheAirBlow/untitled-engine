using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAirBlow.Engine.API.Binary;
using TheAirBlow.Engine.API.Worker;
using TheAirBlow.Engine.Standalone;

namespace TheAirBlow.Engine.API
{
    public static class MainWorker
    {
        internal static bool loaded = false;
        internal static BinaryRoom currentRoom;
        public static EngineGame game;

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
                    if (Loader.data.rooms[0] == null)
                    {
                        Logger.LogException(new Exception("Could not start worker: There is no rooms!"));
                        throw new Exception("Could not start worker: There is no rooms!");
                    }

                    currentRoom = Loader.data.rooms[0];

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
    }
}
