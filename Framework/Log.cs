using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public static class Log
    {
        public static void Error(string message)
        {
            Console.WriteLine($"ERROR [{Time()}]: {message}");
        }

        public static void Info(string message)
        {
            Console.WriteLine($"INFO [{Time()}]: {message}");
        }


        public static void Warning(string message)
        {
            Console.WriteLine($"WARNING [{Time()}]: {message}");
        }

        private static string Time()
        {
            return DateTime.UtcNow.AddHours(1).ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
