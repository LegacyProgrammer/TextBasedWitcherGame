﻿using System;
using System.Collections.Generic;
using System.Linq;
using Text_Bases_RPG.Utility;


namespace Text_Bases_RPG
{
    public class Program
    {
        public static int intResol_Wide = 150, intResol_Long = 50;
        public static List<string> Log = new List<string>();
        public static bool busy;
        public static string Char_Name;
        public static int Game_Over = 0;
        public static int Char_HP_Current = 20;
        public static int Char_HP_Full = 100;
        public static int Char_EXP_Current = 15;
        public static int Char_EXP_Full = 100;
        public static int Char_Level_Current = 1;
        public static int WriteScreen;
        public static int TypeScreen;
        public static bool RightOption;

        static void Main(string[] args)
        {
            
            //Asking for the user's preference of size.
            Console.WriteLine("Choose your width(Between 100 and 200): ");
            intResol_Wide = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Choose your lenght(Between 30 and 70): ");
            intResol_Long = Convert.ToInt16(Console.ReadLine());

            Console.Clear();

            //Console resolution.
            Console.SetWindowSize(intResol_Wide, intResol_Long);
            WriteScreen = intResol_Long - 5;
            TypeScreen = intResol_Long - 3;
            //String for input

            string input;

            
            //Speaks for itself
            Console.WriteLine(@"       ______ __                  ____                  ___    ___                 ____                  __                        __      ");
            Console.WriteLine(@"      /\__  _/\ \                /\  _`\          __  /'___\ /'___\ __            /\  _`\               /\ \__                    /\ \__   ");
            Console.WriteLine(@"      \/_/\ \\ \ \___      __    \ \ \L\_\  _ __ /\_\/\ \__//\ \__//\_\    ___    \ \ \/\_\   ___    ___\ \ ,_\ _ __   __      ___\ \ ,_\  ");
            Console.WriteLine(@"         \ \ \\ \  _ `\  /'__`\   \ \ \L_L /\`'__\/\ \ \ ,__\ \ ,__\/\ \ /' _ `\   \ \ \/_/_ / __`\/' _ `\ \ \//\`'__/'__`\   /'___\ \ \/  ");
            Console.WriteLine(@"          \ \ \\ \ \ \ \/\  __/    \ \ \/, \ \ \/ \ \ \ \ \_/\ \ \_/\ \ \/\ \/\ \   \ \ \L\ /\ \L\ /\ \/\ \ \ \\ \ \/\ \L\.\_/\ \__/\ \ \_ ");
            Console.WriteLine(@"           \ \_\\ \_\ \_\ \____\    \ \____/\ \_\  \ \_\ \_\  \ \_\  \ \_\ \_\ \_\   \ \____\ \____\ \_\ \_\ \__\ \_\ \__/.\_\ \____\\ \__\");
            Console.WriteLine(@"            \/_/ \/_/\/_/\/____/     \/___/  \/_/   \/_/\/_/   \/_/   \/_/\/_/\/_/    \/___/ \/___/ \/_/\/_/\/__/\/_/\/__/\/_/\/____/ \/__/");


            //Asking Name
            Console.SetCursorPosition(40, 20);
            Console.Write("What is the name of this amazing adventurer? ");
            Char_Name = Convert.ToString(Console.ReadLine());

            Console.Clear();

            //Interface weergeven:
            GUI_Interface.ShowGui("Gui");
            //Draw Play Screen
            GUI_Interface.ShowPS("ShowPs");
            //Start the game.
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("Press enter to start the game!");
            Console.ReadLine();
            Console.SetCursorPosition(1, Console.CursorTop - 2);
            W_Line.ClearCurrentConsoleLine();

            //Displaying text.
            W_Line.WLine(Char_Name + ": Woah what happened...");           
            W_Line.WLine(Char_Name + " looks to his left and sees the dead Bruxa laying next to him");           
            W_Line.WLine("It was a tough fight, he sees the blood and sees his own scars");           
            W_Line.WLine("After laying there for a while, you finally remember, you accepted a contract from a village elder to kill the Bruxa...");            
            W_Line.WLine("You don't remember the rest though, try to find out what happened...");
            W_Line.WLine(Char_Name + " sees an apple, some potions and some sort of contract.");
            W_Line.WLine("Do you want to look at the apple, take a potion to regain health or look at the contract?");


            //Asking to answer the options or any other key.
               /* do
                {
                */
                    Console.SetCursorPosition(1, WriteScreen);
                    Console.WriteLine("Type: 'Apple', 'Potion' or 'Contract'.");
                    Console.SetCursorPosition(1, TypeScreen);
                    input = Convert.ToString(Console.ReadLine());
                    W_Line.ClearCurrentConsoleLine();
                    Console.SetCursorPosition(1, WriteScreen);
                    W_Line.ClearCurrentConsoleLine();
                 /*   
                } while (RightOption == false);
            */
                //If the input is 'Potion' you will regain health, if
                if (input.ToLower() == "Potion")
                {
                    RightOption = false;
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.ClearCurrentConsoleLine();
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.WLine("You look at the potion and sip some of it, it tastes like shit but you still take it..");
                    W_Line.ClearCurrentConsoleLine();
                    Char_HP_Current = Char_HP_Current + 80;
                    Console.SetCursorPosition(Convert.ToInt16(GUI_Interface.dblHealth), 2);
                    Console.WriteLine("HP: {0}/{1}", Char_HP_Current, Char_HP_Full);
                    Console.SetCursorPosition(1, WriteScreen);
                    W_Line.ClearCurrentConsoleLine();
                    W_Line.WLineSucces("You took a potion and your health has regenerated to 100.");
                    Console.SetCursorPosition(1, Console.CursorTop - 1);
                    W_Line.ClearCurrentConsoleLine();
                }
                else if (input.ToLower() == "Apple")
                {
                RightOption = false;
                Console.SetCursorPosition(1, TypeScreen);
                W_Line.ClearCurrentConsoleLine();
                W_Line.WLine("You look at the apple and save it for later.");
                }
                else if(input.ToLower() == "Contract")
                {
                RightOption = true;
                Console.SetCursorPosition(1, TypeScreen);
                W_Line.ClearCurrentConsoleLine();
                W_Line.WLine("You look at the contract and see it is The Griffin Contract you got from the village elder. ");
                W_Line.WLineSucces("You remember why you are here again");
                }

            //Enter to go further in the story.
            if (RightOption == true)
            {
                Console.SetCursorPosition(1, WriteScreen);
                Console.WriteLine("Press enter to try to get out of this place..");
                input = Console.ReadLine();
                Console.SetCursorPosition(1, WriteScreen);
                W_Line.ClearCurrentConsoleLine();
                W_Line.WLine("");
            }
            if (input == "")
            {
                W_Line.ClearText();
            }
            
            W_Line.WLine("You stand up and lean on the Bruxa you killed and you are trying to remember some more of what happened...");
            W_Line.WLine("You are remembering that you accepted the contract from the village elder, who told you that there was a Royal Arch Griffin nest on top of");
            W_Line.WLine("the mountain, but you needed to go trough a dungeon to get to the top of the mountain...");
            W_Line.WLine("The moment when you entered the dungeon, you realised that you didn't entered just a normal dungeon...");
            W_Line.WLine("You entered an Elven Ruin and after a while of exploring and trying to get to the top of the mountain, you came past a Bruxa hide-out.");
            W_Line.WLine("The only way to get to the top was trough a cave behind the bruxa itself... So you needed to fight it...");
            W_Line.WLine("While fighting it, you barely killed him but afterwards you fell uncunsious and woke up hours or even days later next to the Bruxa.");



            Console.ReadLine();




        }
    }
}

   

