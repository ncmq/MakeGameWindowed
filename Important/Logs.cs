using System;

namespace MakeGameWindowed.Important
{
    public static class Logs
    {
        public static void Log(string message)
        {
            Console.WriteLine($"{PluginInfo.GUID}: {message}"); 
        }
    }
}
