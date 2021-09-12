using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force.Classes
{
    /// <summary>
    /// Used for debugging
    /// </summary>

    public class Log 
    {
        /// <summary>
        /// Logs a message in the console
        /// </summary>
        /// <param name="message">The message to log</param>

        public static void Default(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[MSG] — {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Logs an info message in the console
        /// </summary>
        /// <param name="message">The message to log</param>

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[INFO] — {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Logs a warning message in the console
        /// </summary>
        /// <param name="message">The message to log</param>

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] — {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Logs an error message in the console
        /// </summary>
        /// <param name="message">The message to log</param>

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ERROR] — {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
