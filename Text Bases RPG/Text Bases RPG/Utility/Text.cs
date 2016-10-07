using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Text_Bases_RPG.Utility
{
    class Text
    {
        public static int textSpeed = 10;

        public static void Read(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(textSpeed);
            }
            Console.WriteLine("");
        }

        public static void Enemy(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Read(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Read(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Success(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Read(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteEnemy()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}


