using ConsoleApplication1;
using System;
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
        public static bool Clearing;

        //ints forinventory.
        public static int Potions = 3;
        public static int Bruxahead;
        public static int Gold = 100;
        static void Main(string[] args)
        {
            
            //Asking for the user's preference of size.
            Console.WriteLine("Choose your width(Between 100 and 200): ");
            intResol_Wide = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Choose your lenght(Between 40 and 50): ");
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


        //logging in.

            login:
            Text.Read("What is your username?");
            string username = Console.ReadLine();
            Player Player = new Player(username);
            if (Player.User != null)
            {
                Text.Read("Welcome, " + Player.Username() + ". Your current hp is: " + Player.currenthp());

                Console.Clear();
            }
            else
            {
            
                Text.Read("-------------------");
                Text.Read("Do you want to make user " + username + " ? Press ENTER");
                Console.ReadLine();
                Player newPlayer = new Player(username, true);

                goto login;
       }

            Console.Clear();

            Char_EXP_Current = Convert.ToInt16(Player.currentxp());
            Char_EXP_Full = Convert.ToInt16(Player.Xp());

            Char_HP_Current = Convert.ToInt16(Player.currenthp());
            Char_HP_Full = Convert.ToInt16(Player.Hp());

            Char_Name = Player.Username();

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
            
            do { 
                    RightOption = false;
                    Console.SetCursorPosition(1, WriteScreen);
                    Console.WriteLine("Type: 'Apple', 'Potion' or 'Contract'.");
                    Console.SetCursorPosition(1, TypeScreen);
                    input = Console.ReadLine();
                    W_Line.ClearCurrentConsoleLine();
                    Console.SetCursorPosition(1, WriteScreen);
                    W_Line.ClearCurrentConsoleLine();


                //Your input will give back a certain answer.
                //input potion.
                    if (input.ToLower() == "potion")
                    {

                    if (Potions > 0)
                    {
                        Potions--;
                        Console.SetCursorPosition(1, TypeScreen);
                        W_Line.ClearCurrentConsoleLine();
                        Console.SetCursorPosition(1, WriteScreen);
                        W_Line.WLine("You look at the potion and sip some of it, it tastes like shit but you still take it..");
                        W_Line.ClearCurrentConsoleLine();
                        Char_HP_Current = Char_HP_Full;
                        Console.SetCursorPosition(Convert.ToInt16(GUI_Interface.dblHealth), 2);
                        Console.WriteLine("HP: {0}/{1}", Char_HP_Current, Char_HP_Full);
                        Console.SetCursorPosition(1, WriteScreen);
                        W_Line.ClearCurrentConsoleLine();
                        W_Line.WLineSucces("You took 1 of the 3 swallow potion you have in your bag and your health has regenerated to 100.");
                        Console.SetCursorPosition(1, Console.CursorTop - 1);
                        W_Line.ClearCurrentConsoleLine();
                        RightOption = false;
                    }
                    else
                    {
                        Console.SetCursorPosition(1, TypeScreen);
                        W_Line.ClearCurrentConsoleLine();
                        Console.SetCursorPosition(1, WriteScreen);
                        W_Line.WLineError("You're all out of potions, try to find or buy some new ones.");
                    }
                    }
                //input apple.
                else if (input.ToLower() == "apple")
                    {
                        Console.SetCursorPosition(1, TypeScreen);
                        W_Line.ClearCurrentConsoleLine();
                        W_Line.WLine("You look at the apple and save it for later because you're not really hungry.");
                        RightOption = false;

                    }
                    //input contract.
                    else if (input.ToLower() == "contract")
                    {
                        Console.SetCursorPosition(1, TypeScreen);
                        W_Line.ClearCurrentConsoleLine();
                        W_Line.WLine("You look at the contract and see it is The Griffin Contract you got from the village elder. ");
                        W_Line.WLineSucces("You remember why you are here again");
                        RightOption = true;

                    }
                    //if input is anything else, you'll return.
                    else
                    {
                        Console.SetCursorPosition(1, TypeScreen);
                        W_Line.ClearCurrentConsoleLine();
                        RightOption = false;
                    }

                } while (RightOption != true);

            //Enter to go further in the story.

                Console.SetCursorPosition(1, WriteScreen);
                Console.WriteLine("Press enter to try to get out of this place..");
                input = Console.ReadLine();
                Console.SetCursorPosition(1, WriteScreen);
                W_Line.ClearCurrentConsoleLine();
                W_Line.WLine("");
            //Going further on.
                W_Line.WLine("You stand up and lean on the Bruxa you killed and you are trying to remember some more of what happened...");
                W_Line.WLine("You are remembering that you accepted the contract from the village elder, who told you that there was a Royal Arch Griffin nest on top of");
                W_Line.WLine("the mountain, but you needed to go trough a dungeon to get to the top of the mountain...");
                W_Line.WLine("The moment when you entered the dungeon, you realised that you didn't entered just a normal dungeon...");
                W_Line.WLine("You entered an Elven Ruin and after a while of exploring and trying to get to the top of the mountain, you came past a Bruxa hide-out.");
                W_Line.WLine("The only way to get to the top was trough a cave behind the bruxa itself... So you needed to fight it...");
                W_Line.WLine("While fighting it, you barely killed him but afterwards you fell uncunsious and woke up hours or even days later next to the Bruxa.");
                W_Line.WLine("");
                W_Line.WLineEnter();
                W_Line.ClearText();

            //Second part of the game.
            W_Line.WLine("Now that you remembered why you are here again, you continue on your search for the Griffin");

            do
            {
                Console.SetCursorPosition(1, WriteScreen);
                Console.WriteLine("Do you want to decapitate the bruxa to make sure that the bruxa is really dead and receive 50 gold? Yes/No?");
                Console.SetCursorPosition(1, TypeScreen);
                input = Console.ReadLine();
                Console.SetCursorPosition(1, TypeScreen);
                W_Line.ClearCurrentConsoleLine();
                Console.SetCursorPosition(1, WriteScreen);
                W_Line.ClearCurrentConsoleLine();
                //if input = yes you will get the head, if no you'll just continue.
                if (input.ToLower() == "yes")
                {
                    Gold = +50;
                    Program.Bruxahead++;
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.ClearCurrentConsoleLine();
                    W_Line.WLine("You decapitated the bruxa with your silver sword and attach some ropes to the head so you can take it with you like a backpack.");
                    W_Line.WLineSucces("The Bruxa's head has been added to your inventory.");
                    W_Line.WLine("");
                    break;
                }
                else if (input.ToLower() == "no")
                {
                    Program.Bruxahead = 0;
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.ClearCurrentConsoleLine();
                    W_Line.WLine("You will leave the bruxa for what it is and go further on your journey.");
                    W_Line.WLine("");
                    break;
                }
            } while (input != "no" & input != "yes");

            //Going on with the story.
           
                W_Line.WLine("When you are back on your feets, you noticed that there isn't a way out, because of the fight, the way you entered collapsed....");
                W_Line.WLineEnemy("Try using your witcher signs to find a way out.");
                Console.SetCursorPosition(1, WriteScreen);
                Console.WriteLine("Type U to use your witchersign!");
            do
            {
                Console.SetCursorPosition(1, TypeScreen);
                input = Console.ReadLine();
                Console.SetCursorPosition(1, WriteScreen);
                W_Line.ClearCurrentConsoleLine();
                Console.SetCursorPosition(1, TypeScreen);
                W_Line.ClearCurrentConsoleLine();
                //Using your witchersign with 'U'
                if (input.ToLower() == "u")
                {
                    RightOption = true;
                    W_Line.WLine("");
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.ClearCurrentConsoleLine();
                    W_Line.WLineSucces("You used your witchersign and you see some kind of word on the wall next to the part that collapsed, it says 'Zireael'");
                    W_Line.WLine("You think about what it could mean... Zireael... Zireael... ");
                    W_Line.WLine("");
                }
                else
                { 
                    RightOption = false;
                }
            } while (RightOption !=true);

            
                W_Line.WLine("Do you want to shout 'Zireael?(Shout) Do you want to search for a way out?(Out) Do you want to take a better look at the text?(Look)");
                W_Line.WLine("");
            do
            {
                Console.SetCursorPosition(1, TypeScreen);
                input = Console.ReadLine();

                if (input.ToLower() == "shout")
                {
                    RightOption = true;
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.ClearCurrentConsoleLine();
                    W_Line.WLineSucces("You shouted 'Zireael' and some kind of click from behind the bruxa, a door slides open, that should be your way out.");
                    W_Line.WLineSucces("You walk through the door, but you are very carful, because you don't know what to expect.");
                    W_Line.WLine("");
                }
                else if (input.ToLower() == "out")
                {
                    RightOption = false;
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.ClearCurrentConsoleLine();
                    W_Line.WLine("You look around you, above you on the roof and you even look under the bruxa for a way out. But nothing...");
                    W_Line.WLine("You just noticed while looking around, that there is some kind of breeze coming from behind the bruxa. Try checking for another way! ");
                    W_Line.WLine("");
                }
                else if (input.ToLower() == "look")
                {
                    RightOption = false;
                    Console.SetCursorPosition(1, TypeScreen);
                    W_Line.ClearCurrentConsoleLine();
                    W_Line.WLine("You use your witcher sign again and look at the text again, but better this time, you feel it, it feels cold..");
                    W_Line.WLine("You think you should use the word with something... You think about shouting it! Try shouting it!");
                    W_Line.WLine("");
                }
                else if (input.ToLower() == "")
                {
                    RightOption = false;
                }
            
            } while (RightOption != true);

            W_Line.WLineEnter();
            W_Line.ClearText();


            Console.ReadLine();




        }
    }
}

   

