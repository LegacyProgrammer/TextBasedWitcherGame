using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Bases_RPG.Utility;

namespace Text_Bases_RPG.Utility
{
    class GUI_Interface
    {
       
        public static int Game_Over = 0;
        public static Double dblAdventurer;
        public static Double dblExp;
        public static Double dblHealth;
        public static Double dblLevel;

        //Method to print the GUI and stats.
        public static void ShowGui(string Gui)
        {
            


            if (Game_Over == 0)
            {
                for (int i = 1; i < Program.intResol_Wide - 1; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("_");
                }

                Console.SetCursorPosition(0, 1);
                Console.Write("/");
                Console.SetCursorPosition(0, 2);
                Console.Write("|");
                Console.SetCursorPosition(0, 3);
                Console.Write(@"\");
                Console.SetCursorPosition(Program.intResol_Wide - 1, 3);
                Console.Write("/");
                Console.SetCursorPosition(Program.intResol_Wide - 1, 2);
                Console.Write("|");
                Console.SetCursorPosition(Program.intResol_Wide - 1, 1);
                Console.Write(@"\");

                for (int i = 1; i < Program.intResol_Wide - 1; i++)
                {
                    Console.SetCursorPosition(i, 3);
                    Console.Write("_");
                }
                //Solutions to write the stats on the right place.
                dblAdventurer = Program.intResol_Wide / 3 * 0.40;
                dblHealth = Program.intResol_Wide / 3 * 1.25;
                dblExp = Program.intResol_Wide / 3 * 1.9;
                dblLevel = Program.intResol_Wide / 3 * 2.50;

                //Printing stats
                Console.SetCursorPosition(Convert.ToInt16(dblAdventurer), 2);
                Console.WriteLine("Adventurer: {0}", Program.Char_Name);
                if (Program.Char_HP_Current < 30)
                {
                    Console.SetCursorPosition(Convert.ToInt16(dblHealth), 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("HP: {0}/{1}", Program.Char_HP_Current, Program.Char_HP_Full);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.SetCursorPosition(Convert.ToInt16(dblHealth), 2);
                    Console.WriteLine("HP: {0}/{1}", Program.Char_HP_Current, Program.Char_HP_Full);
                }
                Console.SetCursorPosition(Convert.ToInt16(dblExp), 2);
                Console.WriteLine("EXP: {0}/ {1}", Program.Char_EXP_Current, Program.Char_EXP_Full);
                Console.SetCursorPosition(Convert.ToInt16(dblLevel), 2);
                Console.WriteLine("Level: {0}", Program.Char_Level_Current);
            }
        }

        public static void ShowPS(String ShowPs)
        {
            if (Game_Over == 0)
            {
                for (int i = 5; i < Program.intResol_Long - 1; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("|");
                    Console.SetCursorPosition(Program.intResol_Wide - 1, i);
                    Console.Write("|");
                }
                for (int i = 1; i < Program.intResol_Wide - 1; i++)
                {
                    Console.SetCursorPosition(i, 4);
                    Console.Write("_");
                    Console.SetCursorPosition(i, Program.intResol_Long - 2);
                    Console.Write("_");
                    Console.SetCursorPosition(i, Program.intResol_Long - 4);
                    Console.Write("_");
                    Console.SetCursorPosition(i, Program.intResol_Long - 6);
                    Console.Write("_");
                }
            }
        }

    }
 }

