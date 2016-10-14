using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Text_Bases_RPG.Utility
{
    class W_Line
    {
        //Variabels.
        public static int indexLog = 0;
        public static int MaxLinePrintAantal = Program.intResol_Long - 12;



        //Method to place text and saves it in the log.
        public static void WLine(string text)
        {
            Program.busy = true;
            Console.SetCursorPosition(1, Program.WriteScreen);
            Text.Read(text);
            Program.Log.Add(text);
            Console.SetCursorPosition(1, Console.CursorTop - 1);
            W_Line.ClearCurrentConsoleLine();
            ReplaceText();

        }
        //Method to place text(enemy) and saves it in the log.
        public static void WLineEnemy(string text)
        {
            Program.busy = true;
            Console.SetCursorPosition(1, Program.WriteScreen);
            Text.Enemy(text);
            Program.Log.Add(text);
            Console.SetCursorPosition(1, Console.CursorTop - 1);
            W_Line.ClearCurrentConsoleLine();
            ReplaceText();


        }
        //Method to place text(error) and saves the line in the log.
        public static void WLineError(string text)
        {
            Program.busy = true;
            Console.SetCursorPosition(1, Program.WriteScreen);
            Text.Error(text);
            Program.Log.Add(text);
            Console.SetCursorPosition(1, Console.CursorTop - 1);
            W_Line.ClearCurrentConsoleLine();
            ReplaceText();

        }
        //Method to place text(Success) and saves the line in the log
        public static void WLineSucces(string text)
        {
            Program.busy = true;
            Console.SetCursorPosition(1, Program.WriteScreen);
            Text.Success(text);
            Program.Log.Add(text);
            Console.SetCursorPosition(1, Console.CursorTop - 1);
            W_Line.ClearCurrentConsoleLine();
            ReplaceText();

        }
        //Method to type a text wich needs an answer
        public static void WLineAnswer(string text)
        {
            Text.Read(text);
        }
        //Method to remove a line and fix the gui.
        public static void ClearCurrentConsoleLine()
        {
            Program.busy = true;
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(1, currentLineCursor);
            for (int i = 5; i < Program.intResol_Long - 1; i++)
            {
                Console.SetCursorPosition(Program.intResol_Wide - 1, i);
                Console.Write("|");
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }
            for (int j = 1; j < Program.intResol_Wide - 1; j++)
            {
                Console.SetCursorPosition(j, Program.intResol_Long - 2);
                Console.Write("_");
            }


        }
        //Methode om text uit de log te halen
        public static void ReplaceText()
        {
            Program.busy = true;

            for (int j = 5; j <= Program.intResol_Long - 4; j++)
            {

                Console.SetCursorPosition(1, j);

                if (indexLog >= Program.Log.Count)
                {
                    j = 5;
                    indexLog = 0;
                    break;
                }
                else
                {
                    WriteLog();
                    indexLog++;
                }
            }
        }

        //Methode om de log in de console te weergeven
        public static void WriteLog()
        {
            Program.busy = true;
            Console.WriteLine(Program.Log[indexLog]);
        }

        //Methode om het scherm leeg te maken vanaf een aantal punten.
        public static void ClearText()
        {
            Program.busy = true;
            for (int i = 5; i < Program.intResol_Long - 6; i++)
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(1, i);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(1, currentLineCursor);
            }
            for (int i = 5; i <= Program.intResol_Long - 2; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(Program.intResol_Wide - 1, i);
                Console.Write("|");
                Console.SetCursorPosition(2, Program.intResol_Long - 4);
            }
        }
      }
   }


