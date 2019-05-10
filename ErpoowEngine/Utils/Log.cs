using System;
using System.Collections.Generic;
using System.Text;

namespace ErpoowEngine.Utils
{
    public static class Log
    {
        public static object Lock = "";

        public static void Write(string message, LogType type = LogType.Normal, string sender = "unknown", bool newLine = false)
        {
            ConsoleColor color;
            switch (type)
            {
                case LogType.Info:
                    color = ConsoleColor.Blue;
                    break;
                case LogType.Success:
                    color = ConsoleColor.Green;
                    break;
                case LogType.Warning:
                    color = ConsoleColor.Yellow;
                    break;
                case LogType.Error:
                    color = ConsoleColor.Red;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }
            Write(message, color, sender, newLine);
        }

        public static void Write(string message, ConsoleColor color, string sender = "unknown", bool newLine = false)
        {
            lock (Lock)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("[" + DateTime.Now.ToString("dd/MM HH:mm:ss") + "]");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("(" + sender + ")");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" - ");
                Console.ForegroundColor = color;
                Console.Write(message);
                if (newLine)
                    Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void WriteLine(string message, LogType type = LogType.Normal, string sender = "unknown")
        {
            Write(message, type, sender, true);
        }

        public static void Normal(string message, string sender = "unknown", bool newLine = true)
        {
            Write(message, LogType.Normal, sender, newLine);
        }

        public static void Info(string message, string sender = "unknown", bool newLine = true)
        {
            Write(message, LogType.Info, sender, newLine);
        }

        public static void Success(string message, string sender = "unknown", bool newLine = true)
        {
            Write(message, LogType.Success, sender, newLine);
        }

        public static void Warning(string message, string sender = "unknown", bool newLine = true)
        {
            Write(message, LogType.Warning, sender, newLine);
        }

        public static void Error(string message, string sender = "unknown", bool newLine = true)
        {
            Write(message, LogType.Error, sender, newLine);
        }
    }

    public enum LogType
    {
        Normal,
        Info,
        Success,
        Warning,
        Error
    }
}
