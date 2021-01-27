using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.Engine.API.Worker
{
    public static class MainRunner
    {
        public static void Start(string dir, bool debug)
        {
            try
            {
                Loader.Load(dir, debug);
                try { Application.Run(Loader.form); }
                catch { Loader.form.Show(); }
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: An error occured while the game was loading or while the game loop." +
                    "\nWe'd recommend send game's developer file \"game.log\" in the game's folder.", e);
            }
        }
    }
}
