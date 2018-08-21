using System;
using System.IO;

namespace HaxNET___The_Hacking_Simulator
{
    class GameInstance
    {
        private bool status = false;
        private static string saveLocation = Directory.GetCurrentDirectory() + "/saves/";
        private static string fileContents;

        static Random NumberGenerator = new Random();//need this for ip adress generation

        public GameInstance()
        {
            Directory.CreateDirectory(saveLocation);
        }//create game save location

        public static string ipGenerator()//the ip adress generator
        {
            string ip;
            int block1;
            int block2;
            int block3;
            int block4;
            block1 = NumberGenerator.Next(10, 99);
            block2 = NumberGenerator.Next(100, 999);
            block3 = NumberGenerator.Next(100, 999);
            block4 = NumberGenerator.Next(100, 999);
            return ip = block1 + "." + block2 + "." + block3 + "." + block4;
        }

        public static int randomNumber(int floor, int roof)
        {
            return NumberGenerator.Next(floor, roof);
        }//generates a random number

        public string loadGame(string path)
        {
            StreamReader loadGame = new StreamReader(File.Open(path, FileMode.Open));
            fileContents = loadGame.ReadLine();
            loadGame.Close();
            path = "";
            return fileContents;
        }//load save files

        public static void close()
        {
            Environment.Exit(0);
        }//close the game instance

        public bool SaveCheck()
        {
            int count = 0;
            string[] files = new string[]{Player.HealthSave, Player.BitcoinSave, Player.FireWallSave, Player.CrackerSave, Player.OsSave, Player.PlayerNameSave, Player.PlayerTitleSave, Player.ScannerSave, Player.XpSave, Player.DownloadSpeedSave, Player.UploadSpeedSave, Player.ConnectionSave};
            if (Directory.Exists(Player.SaveLocation))//begin by checking for the save directory
            {
                for (var i = 0; i < files.Length; i++)//check each filename found in array: files
                {
                    var item = files[i];
                    if (File.Exists(item))
                    {
                        count++;
                    }
                    else
                        count--;
                }
                if (count == files.Length)//check if all exist
                    return status = true;
                else
                    return status = false;
            }
            return status = false;//if main directory does not exist
        }//checks for the existence of user save files

        public bool checkForfile(string path)
        {
            return File.Exists(saveLocation + path);
        }//check for the existance of a save

        public bool checkForfolder(string path)
        {
            return Directory.Exists(path);
        }//checks for a specific folder

        public bool checkForloseGame(int playerHealth)
        {
            if (playerHealth == 0)
            {
                return true;
            }
            else
                return false;
        }//checks for the existance of a lose game

        public static void resetAll()
        {
            string[] saves = new string[] { Player.HealthSave, Player.BitcoinSave, Player.FireWallSave, Player.CrackerSave, Player.OsSave, Player.PlayerNameSave, Player.PlayerTitleSave, Player.ScannerSave, Player.XpSave, Player.DownloadSpeedSave, Player.UploadSpeedSave, Player.ConnectionSave };
            for (int i = 0; i < saves.Length; i++)
            {
                File.Delete(saves[i]);
            }
        }//resets the entire game
    }
}
