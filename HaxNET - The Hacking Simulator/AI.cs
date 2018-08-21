using System;
using System.IO;

namespace HaxNET___The_Hacking_Simulator
{
    class AI
    {
        private static string ip;//make required variable for public AI()
        private static string saveLocation = Directory.GetCurrentDirectory() + "/saves/ai/" + ip + "/";//make variables for all save data for EACH INDIVIDUAL AI
        GameInstance HaxNet = new GameInstance();
        public AI(string address, bool loadAI, string path)
        {
            if (loadAI == true)
            {
                if (Directory.Exists(savesForAi + "/" + address + "/"))
                {
                    ip = address;
                    string[] saves = Directory.GetFiles(path + "/" + address + "/");
                    try
                    {
                        for (int i = 0; i <= saves.Length; i++)//load each save into memory
                        {
                            switch (i)
                            {
                                case 0:
                                    Bitcoin = Convert.ToInt32(HaxNet.loadGame(saves[i]));
                                    break;
                                case 1:
                                    Cracker = Convert.ToDouble(HaxNet.loadGame(saves[i]));
                                    break;
                                case 2:
                                    Firewall = Convert.ToDouble(HaxNet.loadGame(saves[i]));
                                    break;
                                case 3:
                                    health = Convert.ToInt32(HaxNet.loadGame(saves[i]));
                                    break;
                                case 4:
                                    AiName = HaxNet.loadGame(saves[i]);
                                    break;
                                case 5:
                                    OperatingSystem = Convert.ToDouble(HaxNet.loadGame(saves[i]));
                                    break;
                                case 6:
                                    Scanner = Convert.ToDouble(HaxNet.loadGame(saves[i]));
                                    break;
                                case 7:
                                    AiTitle = HaxNet.loadGame(saves[i]);
                                    break;
                                default:
                                    Console.Write(".");
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
                    Console.WriteLine("");
                }
                else
                    Console.WriteLine("Error: connection to [{0}] lost.", ip);
            }
            else
                Console.WriteLine("...");
        }

        private int bitcoin = 100;
        private int health = 100;
        private double firewall = 1.0;
        private double cracker = 1.0;
        private double scanner = 1.0;
        private double operatingSystem = 1.0;
        private double xp = 0.0;
        private string aiName;
        private string aiTitle = "Whitehat";

        private static string fileType = "hxnet";
        private static string savesForAi = Directory.GetCurrentDirectory() + "/saves/ai/";
        private static string healthSave = saveLocation.ToString() + "h." + fileType;
        private static string bitcoinSave = saveLocation.ToString() + "bit." + fileType;
        private static string fireWallSave = saveLocation.ToString() + "fwall." + fileType;
        private static string crackerSave = saveLocation.ToString() + "crak." + fileType;
        private static string scannerSave = saveLocation.ToString() + "scn." + fileType;
        private static string osSave = saveLocation.ToString() + "os." + fileType;
        private static string xpSave = saveLocation.ToString() + "xp." + fileType;
        private string aiNameSave = saveLocation.ToString() + "nm." + fileType;
        private string aiTitleSave = saveLocation.ToString() + "ttl." + fileType;

        public int Bitcoin
        {
            get
            {
                return bitcoin;
            }

            set
            {
                bitcoin = value;
            }
        }

        public double Firewall
        {
            get
            {
                return firewall;
            }

            set
            {
                firewall = value;
            }
        }

        public double Cracker
        {
            get
            {
                return cracker;
            }

            set
            {
                cracker = value;
            }
        }

        public double Scanner
        {
            get
            {
                return scanner;
            }

            set
            {
                scanner = value;
            }
        }

        public double OperatingSystem
        {
            get
            {
                return operatingSystem;
            }

            set
            {
                operatingSystem = value;
            }
        }

        public double Xp
        {
            get
            {
                return xp;
            }

            set
            {
                xp = value;
            }
        }

        public string AiName
        {
            get
            {
                return aiName;
            }

            set
            {
                aiName = value;
            }
        }

        public string AiTitle
        {
            get
            {
                return aiTitle;
            }

            set
            {
                aiTitle = value;
            }
        }

        public static string HealthSave
        {
            get
            {
                return healthSave;
            }
        }

        public static string BitcoinSave
        {
            get
            {
                return bitcoinSave;
            }
        }

        public static string FireWallSave
        {
            get
            {
                return fireWallSave;
            }
        }

        public static string CrackerSave
        {
            get
            {
                return crackerSave;
            }
        }

        public static string ScannerSave
        {
            get
            {
                return scannerSave;
            }
        }

        public static string OsSave
        {
            get
            {
                return osSave;
            }
        }

        public string AiNameSave
        {
            get
            {
                return aiNameSave;
            }
        }

        public string AiTitleSave
        {
            get
            {
                return aiTitleSave;
            }
        }

        public static string XpSave
        {
            get
            {
                return xpSave;
            }
        }

        public void saveAI(string address)
        {
            string[] path = new string[] { bitcoinSave, fireWallSave, crackerSave, scannerSave, osSave, xpSave, aiNameSave, aiTitleSave };
            string[] contents = new string[] { bitcoin.ToString(), firewall.ToString(), cracker.ToString(), scanner.ToString(), operatingSystem.ToString(), xp.ToString(), aiName, aiTitle};
            for (int i = 0; i < path.Length; i++)
            {
                string item = path[i];
                string content = contents[i];
                File.Delete(item);
                StreamWriter saveGame = new StreamWriter(File.Open(item, FileMode.OpenOrCreate));
                saveGame.Write(content);
                saveGame.Close();
            }
        }//save game status to a file

        public static string saveFolder()
        {
            return Directory.GetCurrentDirectory() + "/saves/ai/";
        }
    }
}
