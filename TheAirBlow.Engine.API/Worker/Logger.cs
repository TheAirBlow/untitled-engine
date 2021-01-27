using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAirBlow.Engine.API.Worker
{
    internal static class Logger
    {
        internal static string path;
        internal static StreamWriter writer;

        internal static void Log(string msg)
        {
            if (path != null)
            {
                if (writer == null)
                {
                    if (File.Exists(path + "\\game.log")) File.Delete(path + "\\game.log");
                    writer = File.AppendText(path + "\\game.log");
                }
                writer.WriteLine(GetCurrentTime() + msg);
                writer.Flush();
            }
        }

        internal static void LogException(Exception e)
        {
            if (path != null)
            {
                if (writer == null)
                {
                    if (File.Exists(path + "\\game.log")) File.Delete(path + "\\game.log");
                    writer = File.AppendText(path + "\\game.log");
                }
                writer.WriteLine(GetCurrentTime() + e.ToString());
                writer.Flush();
            }
        }

        internal static string GetCurrentTime()
        {
            return DateTime.Now.ToString(@"[hh\:mm\:ss] ");
        }
    }
}
