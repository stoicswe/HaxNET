using System;
using System.IO;

namespace HaxNET___The_Hacking_Simulator
{
    class AIManager
    {
        static Random numGen = new Random();
        private static string fileType = "hxnet";
        string aiManagerMasterFile = Directory.GetCurrentDirectory() + "/aiman.hxnet";
        private static string saveLocation = Directory.GetCurrentDirectory() + "/saves/ai/";//make variables for all save data for EACH INDIVIDUAL AI

        public static double aiFirewallLevel(string path)
        {
            double val;
            StreamReader aiFirewall_Level = new StreamReader(File.Open(path + "fwall." + fileType, FileMode.Open));
            val = Convert.ToDouble(aiFirewall_Level.ReadLine());
            aiFirewall_Level.Close();
            return val;
        }//find firewall level of selected ai

        public static string generateAIName()
        {
            int namelength = GameInstance.randomNumber(5, 12);
            int character;
            string name = "";
            for (int i = 0; i < namelength; i++)
            {
                character = GameInstance.randomNumber(1, 27);
                switch (character){
                    case 1:
                        name += "a";
                        break;
                    case 2:
                        name += "b";
                        break;
                    case 3:
                        name += "c";
                        break;
                    case 4:
                        name += "d";
                        break;
                    case 5:
                        name += "e";
                        break;
                    case 6:
                        name += "f";
                        break;
                    case 7:
                        name += "g";
                        break;
                    case 8:
                        name += "h";
                        break;
                    case 9:
                        name += "i";
                        break;
                    case 10:
                        name += "j";
                        break;
                    case 11:
                        name += "k";
                        break;
                    case 12:
                        name += "l";
                        break;
                    case 13:
                        name += "m";
                        break;
                    case 14:
                        name += "n";
                        break;
                    case 15:
                        name += "o";
                        break;
                    case 16:
                        name += "p";
                        break;
                    case 17:
                        name += "q";
                        break;
                    case 18:
                        name += "r";
                        break;
                    case 19:
                        name += "s";
                        break;
                    case 20:
                        name += "t";
                        break;
                    case 21:
                        name += "u";
                        break;
                    case 22:
                        name += "v";
                        break;
                    case 23:
                        name += "w";
                        break;
                    case 24:
                        name += "x";
                        break;
                    case 25:
                        name += "y";
                        break;
                    case 26:
                        name += "z";
                        break;
                    default:
                        name += "_";
                        break;
                }
            }
            return name;
        }//generate a name for ai player NOTE: name does not follow standard english rules!

        public static string generateAITitle(double xp)
        {
            if (xp > 12.0)
            {
                return "BlackHat";
            }
            else
                return "WhiteHat";
        }//give ai a title

        public static void generateAI(string ip)
        {
            int num;
            string newSaveLocation = saveLocation + "/" + ip + "/";
            Directory.CreateDirectory(newSaveLocation);
            string healthSave = newSaveLocation.ToString() + "h." + fileType;
            string bitcoinSave = newSaveLocation.ToString() + "bit." + fileType;
            string fireWallSave = newSaveLocation.ToString() + "fwall." + fileType;
            string crackerSave = newSaveLocation.ToString() + "crak." + fileType;
            string scannerSave = newSaveLocation.ToString() + "scn." + fileType;
            string osSave = newSaveLocation.ToString() + "os." + fileType;
            string xpSave = newSaveLocation.ToString() + "xp." + fileType;
            string aiNameSave = newSaveLocation.ToString() + "nm." + fileType;
            string aiTitleSave = newSaveLocation.ToString() + "ttl." + fileType;
            int health = 100;
            double firewall = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Cracker - 1), Convert.ToInt32(Player.Cracker + 20)));
            int bitcoin = 100;
            num = numGen.Next(1, 5);
            if (num > 3)
            {
                bitcoin = Convert.ToInt32(Player.Cracker) * 200;
            }
            else
            if (num <= 3)
            {
                bitcoin = GameInstance.randomNumber(1, 100) * Convert.ToInt32(firewall - (Player.Cracker));
                if (bitcoin < 0)
                {
                    bitcoin = bitcoin * (-1);
                }
            }
            double cracker = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Cracker), Convert.ToInt32(Player.Cracker + 20)));
            double scanner = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Scanner), Convert.ToInt32(Player.Scanner + 20)));
            double operatingSystem = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.OperatingSystem + 1.0), Convert.ToInt32(Player.OperatingSystem + 5.0)));
            double xp = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Xp), Convert.ToInt32(Player.Xp + 20.0)));
            string aiName = generateAIName();
            string aiTitle = generateAITitle(xp);

            string[] path = new string[] { healthSave, bitcoinSave, fireWallSave, crackerSave, scannerSave, osSave, xpSave, aiNameSave, aiTitleSave };
            string[] contents = new string[] { health.ToString(), bitcoin.ToString(), firewall.ToString(), cracker.ToString(), scanner.ToString(), operatingSystem.ToString(), xp.ToString(), aiName, aiTitle };
            for (int i = 0; i < path.Length; i++)
            {
                string item = path[i];
                string content = contents[i];
                StreamWriter saveAI = new StreamWriter(File.Open(item, FileMode.OpenOrCreate));
                saveAI.Write(content);
                saveAI.Close();
            }
        }//generate a new ai

        public static void generateAI(string ip, bool connectTrue)
        {
            string newSaveLocation = saveLocation + "/" + ip + "/";
            Directory.CreateDirectory(newSaveLocation);
            string healthSave = newSaveLocation.ToString() + "h." + fileType;
            string bitcoinSave = newSaveLocation.ToString() + "bit." + fileType;
            string fireWallSave = newSaveLocation.ToString() + "fwall." + fileType;
            string crackerSave = newSaveLocation.ToString() + "crak." + fileType;
            string scannerSave = newSaveLocation.ToString() + "scn." + fileType;
            string osSave = newSaveLocation.ToString() + "os." + fileType;
            string xpSave = newSaveLocation.ToString() + "xp." + fileType;
            string aiNameSave = newSaveLocation.ToString() + "nm." + fileType;
            string aiTitleSave = newSaveLocation.ToString() + "ttl." + fileType;
            int health = 100;
            int bitcoin = GameInstance.randomNumber(1, 10000000);
            double firewall = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Firewall), Convert.ToInt32(Player.Firewall + 100)));
            double cracker = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Cracker), Convert.ToInt32(Player.Cracker + 100)));
            double scanner = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Scanner), Convert.ToInt32(Player.Scanner + 100)));
            double operatingSystem = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.OperatingSystem), Convert.ToInt32(Player.OperatingSystem + 37)));
            double xp = Convert.ToDouble(GameInstance.randomNumber(Convert.ToInt32(Player.Xp), Convert.ToInt32(Player.Xp + 500.0)));
            string aiName = generateAIName();
            string aiTitle = generateAITitle(xp);

            string[] path = new string[] { healthSave, bitcoinSave, fireWallSave, crackerSave, scannerSave, osSave, xpSave, aiNameSave, aiTitleSave };
            string[] contents = new string[] { health.ToString(), bitcoin.ToString(), firewall.ToString(), cracker.ToString(), scanner.ToString(), operatingSystem.ToString(), xp.ToString(), aiName, aiTitle };
            for (int i = 0; i < path.Length; i++)
            {
                string item = path[i];
                string content = contents[i];
                StreamWriter saveAI = new StreamWriter(File.Open(item, FileMode.OpenOrCreate));
                saveAI.Write(content);
                saveAI.Close();
            }
        }

    }
}
