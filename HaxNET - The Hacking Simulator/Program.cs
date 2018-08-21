using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Speech.Synthesis;

namespace HaxNET___The_Hacking_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "<<<<<HaxNET>>>>>";//title for game window
            Directory.CreateDirectory(Player.SaveLocation);//create save directory
            SpeechSynthesizer talk = new SpeechSynthesizer();//just in case if the program needs speech synthesis
            GameInstance HaxNet = new GameInstance();//make new game process, set window height/size 500, 500
            CommandManager HaxCommand = new CommandManager();//add new manager for sorting out user-commands

            Animation.studioAnimation();//play studio animation
            Animation.startupAnimation();

            string command;//initialize game variable


        instructionLoop:
            Console.WriteLine("");
            Console.WriteLine("Welcome to HaxNET, the PC hacking simulation platform.");//make players feel welcome
            Console.Write("Do you need instruction? (y/n): ");//ask if they need some instruction
            command = Console.ReadLine();
            if (command == "y")
            {
                HaxCommand.instruct();
                goto start;
            }
            else
                if (command == "n")
            {
                goto start;
            }
            else
                Console.WriteLine("Error! Incorrect char entered");
                goto instructionLoop;


        start://begin doing interesting stuff
            command = "";
            Animation.loadingAnimation();//play the game loading animation
            if (HaxNet.SaveCheck())//check for a save file
            {
                goto yesSave;
            }
            else
                goto noSave;


            noSave:
            Console.WriteLine("No user save found!");//begin new game if no save files found
            Console.WriteLine("Beginning new game....");
            Console.WriteLine("-----------------------------------------------------------");
            Console.Write("Please type a username: ");
            Player.PlayerName = Console.ReadLine();
            Console.WriteLine("-----------------------------------------------------------");
            Player.savePlayer();
            goto MainLoop;


        yesSave:
            Console.WriteLine("Done save check.");//load the saved game
            try
            {
                string[] loadfiles = new string[] { Player.BitcoinSave, Player.CrackerSave, Player.FireWallSave, Player.HealthSave, Player.OsSave, Player.PlayerNameSave, Player.PlayerTitleSave, Player.ScannerSave, Player.XpSave, Player.DownloadSpeedSave, Player.UploadSpeedSave, Player.ConnectionSave, Player.IpAddressSave };//get save file locations
                for (int i = 0; i <= loadfiles.Length; i++)//load each save into memory
                {
                    switch (i)
                    {
                        case 0:
                            Player.Bitcoin = Convert.ToInt32(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 1:
                            Player.Cracker = Convert.ToInt32(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 2:
                            Player.Firewall = Convert.ToDouble(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 3:
                            Player.Health = Convert.ToInt32(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 4:
                            Player.OperatingSystem = Convert.ToDouble(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 5:
                            Player.PlayerName = HaxNet.loadGame(loadfiles[i]);
                            break;
                        case 6:
                            Player.PlayerTitle = HaxNet.loadGame(loadfiles[i]);
                            break;
                        case 7:
                            Player.Scanner = Convert.ToDouble(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 8:
                            Player.Xp = Convert.ToDouble(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 9:
                            Player.Downspeed = Convert.ToDouble(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 10:
                            Player.UpSpeed = Convert.ToDouble(HaxNet.loadGame(loadfiles[i]));
                            break;
                        case 11:
                            Player.ConnectionStatus = HaxNet.loadGame(loadfiles[i]);
                            break;
                        case 12:
                            Player.IpAddress = HaxNet.loadGame(loadfiles[i]);
                            break;
                        default:
                            Console.WriteLine("Done.");
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error! Save files corrupted!");//if one or more save files throws an exception
                string t = Console.ReadLine();
                GameInstance.resetAll();
                GameInstance.close();
            }
            Console.WriteLine("done");
            goto MainLoop;


        MainLoop://finally! the main game processes!
            Player.savePlayer();
            if (HaxNet.checkForloseGame(Player.Health) == true)
            {
                Animation.loseGame();
                Player.savePlayer();
                GameInstance.resetAll();
                GameInstance.close();
            }
            else
            Console.Write(Player.PlayerName + "@hax.net>");
            command = Console.ReadLine();
            if (Player.Viruses > 0)
            {
                for(int i = 0; i < Animation.defaultTime*Player.Viruses; i++)
                {

                }
            }
            Logic.aiLogic();
            string[] commandArgs = command.Split(' ');//check if more than one argument entered
            var e = from s in commandArgs
                    select s;
            int c = e.Count();
            if (c > 1)//if more than one argument
            {
                if (c > 2)//if three arguments
                {
                    Console.WriteLine("Too many arguments for this command!");
                }
                else
                    if (c == 2)//if two arguments
                    HaxCommand.action(commandArgs[0], commandArgs[1]);
                else//if more than three arguments
                    Console.WriteLine("Command not found!");
            }
            else
            HaxCommand.action(command);//else take normal action

            goto MainLoop;//loop

        }
    }
}
