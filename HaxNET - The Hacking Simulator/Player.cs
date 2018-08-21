using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HaxNET___The_Hacking_Simulator
{
    class Player
    {
        private static int health = 100;//create required variables for class player
        private static int bitcoin = 1500;
        private static double firewall = 1.0;
        private static double cracker = 1.0;
        private static double scanner = 1.0;
        private static int viruses = 0;
        private static double operatingSystem = 1.0;
        private static double xp = 0.0;
        private static double downSpeed = 0.2;
        private static double upSpeed = 0.1;
        private static string playerName;
        private static string playerTitle = "Whitehat";
        private static string connectionStatus = "Online";
        private static string ipAddress = GameInstance.ipGenerator().ToString();

        private static string fileType = "hxnet";
        private static string saveLocation = Directory.GetCurrentDirectory() + "/saves/user/";//user save file locations
        private static string healthSave = saveLocation.ToString() + "h." + fileType;
        private static string bitcoinSave = saveLocation.ToString() + "bit." + fileType;
        private static string fireWallSave = saveLocation.ToString() + "fwall." + fileType;
        private static string crackerSave = saveLocation.ToString() + "crak." + fileType;
        private static string scannerSave = saveLocation.ToString() + "scn." + fileType;
        private static string osSave = saveLocation.ToString() + "os." + fileType;
        private static string xpSave = saveLocation.ToString() + "xp." + fileType;
        private static string playerNameSave = saveLocation.ToString() + "nm." + fileType;
        private static string playerTitleSave = saveLocation.ToString() + "ttl." + fileType;
        private static string downloadSpeedSave = saveLocation.ToString() + "dwn." + fileType;
        private static string uploadSpeedSave = saveLocation.ToString() + "up." + fileType;
        private static string connectionSave = saveLocation.ToString() + "conekt." + fileType;
        private static string ipAddressSave = saveLocation.ToString() + "ip." + fileType;

        public Player()//initialize player
        {
            Directory.CreateDirectory(saveLocation);
        }

        public static int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public static int Bitcoin
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

        public static double OperatingSystem
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

        public static double Xp
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

        public static string PlayerTitle
        {
            get
            {
                return playerTitle;
            }

            set
            {
                playerTitle = value;
            }
        }

        public static string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }

        public static string ConnectionStatus
        {
            get
            {
                return connectionStatus;
            }

            set
            {
                connectionStatus = value;
            }
        }

        public static double Downspeed
        {
            get
            {
                return downSpeed;
            }

            set
            {
                downSpeed = value;
            }
        }

        public static double UpSpeed
        {
            get
            {
                return upSpeed;
            }

            set
            {
                upSpeed = value;
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

        public static string XpSave
        {
            get
            {
                return xpSave;
            }
        }

        public static string PlayerNameSave
        {
            get
            {
                return playerNameSave;
            }
        }

        public static string PlayerTitleSave
        {
            get
            {
                return playerTitleSave;
            }
        }

        public static string SaveLocation
        {
            get
            {
                return saveLocation;
            }
        }

        public static string DownloadSpeedSave
        {
            get
            {
                return downloadSpeedSave;
            }
        }

        public static string UploadSpeedSave
        {
            get
            {
                return uploadSpeedSave;
            }
        }

        public static string ConnectionSave
        {
            get
            {
                return connectionSave;
            }
        }

        public static int Viruses
        {
            get
            {
                return viruses;
            }

            set
            {
                viruses = value;
            }
        }

        public static double Firewall
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

        public static double Cracker
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

        public static double Scanner
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

        public static string IpAddressSave
        {
            get
            {
                return ipAddressSave;
            }
        }

        public static string IpAddress
        {
            get
            {
                return ipAddress;
            }

            set
            {
                ipAddress = value;
            }
        }

        public static void RefreshHud()
        {
            Console.WriteLine("===_<System Monitor>_==========================================================");
            Console.WriteLine("|Firewall Integrity:  " + firewall);
            Console.WriteLine("|Bitcoins in Storage: " + bitcoin);
            Console.WriteLine("|Connection Status:   " + connectionStatus);
            Console.WriteLine("===============================================================================");
        }

        public static void savePlayer()
        {
            string[] path = new string[] { HealthSave, BitcoinSave, FireWallSave, CrackerSave, OsSave, PlayerNameSave, PlayerTitleSave, ScannerSave, XpSave, DownloadSpeedSave, UploadSpeedSave, ConnectionSave, ipAddressSave};
            string[] contents = new string[] { Health.ToString(), Bitcoin.ToString(), Firewall.ToString(), Cracker.ToString(), OperatingSystem.ToString(), PlayerName, PlayerTitle, Scanner.ToString(), Xp.ToString(), downSpeed.ToString(), upSpeed.ToString(), connectionStatus, ipAddress};
            for (int i = 0; i < path.Length; i++)
            {
                string item = path[i];
                string content = contents[i];
                try
                {
                    File.Delete(item);
                }
                catch
                {
                    Console.WriteLine("savePlayer(File.Delete) return inoperatable....no big deal, continue...");
                }
                StreamWriter saveGame = new StreamWriter(File.Open(item, FileMode.OpenOrCreate));
                saveGame.Write(content);
                saveGame.Close();
            }
        }//save everything done to [player]

        public static double toolsSizeAverage()
        {
            return (firewall + cracker + scanner + operatingSystem) / 4.0;
        }//average of all numbers for variables: scanner, firewall, operatingSystem, cracker
    }
}
