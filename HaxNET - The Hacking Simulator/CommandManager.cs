using System;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace HaxNET___The_Hacking_Simulator
{
    class CommandManager//for taking care of all commands entered into the mainloop
    {
        private static string aiSaveLocation = Directory.GetCurrentDirectory() + "/saves/ai/";
        private static double haxnetVersion = 1.17;//please update if any changes are made!

        public void help()
        {
            Console.WriteLine("");
            Console.WriteLine("============================== Help ==============================");
            Console.WriteLine("?             | brings up the help menu");
            Console.WriteLine("about         | shows info about the computer");
            Console.WriteLine("account       | displays bitcoin account info");
            Console.WriteLine("clear         | clears the console");
            Console.WriteLine("clr           | a short-hand for clear");
            Console.WriteLine("connect <arg> | connect tool, connect arg");
            Console.WriteLine("datetime      | displays current date and time");
            Console.WriteLine("exit          | exits the HaxNET program, saves all changes");
            Console.WriteLine("hack <arg>    | exploit tool, hack arg");
            Console.WriteLine("help          | brings up this menu");
            Console.WriteLine("ls            | brings up the help menu");
            Console.WriteLine("mscan         | scans drive for viruses");
            Console.WriteLine("netscan       | scan the HaxNet network for available computers");
            Console.WriteLine("resetall      | reset all stats and saves to factory settings");
            Console.WriteLine("tree          | displays all folders/files on drive");
            Console.WriteLine("tutorial      | diaplays tutorial as if first start of game");
            Console.WriteLine("vol           | displays disk volume information");
            Console.WriteLine("==================================================================");
            Console.WriteLine("");
        }//help menu command

        public void dir()
        {
            Filesystem.Tree();
        }

        public void dir(string arg)
        {
            if (arg == "-h")
            {
                Console.WriteLine("");
                Console.WriteLine("========== Help Dir ==========");
                Console.WriteLine("help     | Brings up this menu");
                Console.WriteLine("list     | list files/folders");
                Console.WriteLine("quitDir  | exits Dir");
                Console.WriteLine("about    | about Dir");
                Console.WriteLine("==============================");
                Console.WriteLine("");
            }
        }

        public void hack(string ip)//the hack program method
        {
            if (Directory.Exists(aiSaveLocation + ip))
            {
                Console.WriteLine("Connecting to: [{0}]", ip);
                for (int i = 0; i < Animation.defaultTime/Player.UpSpeed; i++)
                {
                }
                AI hackAI = new AI(ip, true, aiSaveLocation);
                if (Logic.chnaceOfSuccess(Player.Cracker, hackAI.Firewall))
                {
                    Console.WriteLine("Connected to: [{0}]", ip);
                    Player.Xp += Player.Xp * (hackAI.Firewall / 50);
                    Player.savePlayer();
                    string hackCommand = "";
                    while (true)
                    {
                        Console.Write(Player.PlayerName + "@hax.net/hack[{0}]>", ip);
                        hackCommand = Console.ReadLine();
                        string[] commandArgs = hackCommand.Split(' ');//check if more than one argument entered
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
                            {
                                if (commandArgs[0] == "download")
                                {
                                    if (commandArgs[1] == "cracker")
                                    {
                                        Animation.downloadAnimation(commandArgs[1], Player.Downspeed);
                                        Player.Cracker = hackAI.Cracker;
                                        Player.savePlayer();
                                    }
                                    else
                                    if (commandArgs[1] == "scanner")
                                    {
                                        Animation.downloadAnimation(commandArgs[1], Player.Downspeed);
                                        Player.Scanner = hackAI.Scanner;
                                        Player.savePlayer();
                                    }
                                    else
                                    if (commandArgs[1] == "firewall")
                                    {
                                        Animation.downloadAnimation(commandArgs[1], Player.Downspeed);
                                        Player.Firewall = hackAI.Firewall;
                                        Player.savePlayer();
                                    }
                                    else
                                        Console.WriteLine("No such tool [{0}] found! (did you enter tool starting with capital letter?)", commandArgs[1]);
                                }
                                else
                                if (commandArgs[0] == "trans")
                                {
                                    try
                                    {
                                        if (Convert.ToInt32(commandArgs[1]) > hackAI.Bitcoin)
                                            Console.WriteLine("Not enought bitcoins in account: [{0}]", ip);
                                        else
                                            Player.Bitcoin += Convert.ToInt32(commandArgs[1]);
                                        hackAI.Bitcoin -= Convert.ToInt32(commandArgs[1]);
                                        Player.savePlayer();
                                        hackAI.saveAI(ip);
                                        Console.WriteLine();
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Incorrect bitcoin value entrered!");
                                    }
                                }
                                else
                                if (commandArgs[0] == "upgrade")
                                {
                                    try
                                    {
                                        if (Convert.ToDouble(commandArgs[1]) == hackAI.OperatingSystem)
                                        {
                                            Animation.downloadAnimation(commandArgs[0], Player.Downspeed);
                                            Animation.upgradeOperatingSystem(Player.OperatingSystem);
                                            Player.OperatingSystem = hackAI.OperatingSystem;
                                            Player.savePlayer();
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Incorrect OS Iamge Version!");
                                    }
                                }
                                else
                                    Console.WriteLine("Incorrect command entered!");
                            }
                            else//if more than three arguments
                                Console.WriteLine("Command not found!");
                        }
                        else
                        if (hackCommand == "list")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("=============== [{0}] ===============", ip);
                            Console.WriteLine("Bitcoin(s): " + hackAI.Bitcoin);
                            Console.WriteLine("Cracker: " + hackAI.Cracker);
                            Console.WriteLine("Firewall: " + hackAI.Firewall);
                            Console.WriteLine("Operating System: " + hackAI.OperatingSystem);
                            Console.WriteLine("Virus Scanner: " + hackAI.Scanner);
                            Console.WriteLine("=====================================");
                            Console.WriteLine("");
                        }
                        else
                        if (hackCommand == "disconnect")
                        {
                            break;
                        }
                        else
                        if (hackCommand == "help")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("================ Hack Tool Help ================");
                            Console.WriteLine("download <tool>       | Download/Install <tool>");
                            Console.WriteLine("disconnect            | disconnect from currently");
                            Console.WriteLine("                        connected machine");
                            Console.WriteLine("help                  | brings up help menu");
                            Console.WriteLine("list                  | shows all programs on");
                            Console.WriteLine("                        connected machine");
                            Console.WriteLine("trans <bitcoinAmount> | Transfer <bitcoinAmount>");
                            Console.WriteLine("                        to your bitcoin wallet");
                            Console.WriteLine("upgrade <OSImageVer>  | Upgrade using custom OS");
                            Console.WriteLine("                        image found on connected");
                            Console.WriteLine("                        machine");
                            Console.WriteLine("================================================");
                            Console.WriteLine("");
                        }
                        else
                        if (hackCommand == "clear" || hackCommand == "clr")
                        {
                            clear();
                        }
                        else
                            Console.WriteLine("No such command found!");
                    }
                    Console.WriteLine("Disconnected from ip [{0}]", ip);
                }
                else
                    Console.WriteLine("Exploitation of [{0}] failed.", ip);
            }
            else
                Console.WriteLine("No such ip [{0}] found on the network!", ip);
        }

        public void hack(string ip, string args)
        {
            if (args == "-h")
            {
                Console.WriteLine("");
                Console.WriteLine("============ Hack Help =============");
                Console.WriteLine("-h        | Brings up help menu");
                Console.WriteLine("hack <ip> | Hacks <ip> address");
                Console.WriteLine("");
                Console.WriteLine("Hack tool is used to exploit an ip");
                Console.WriteLine("address and download new tools and/or");
                Console.WriteLine("withdraw bitcoins from <ip> account");
                Console.WriteLine("====================================");
                Console.WriteLine("");
            }
            else
            Console.WriteLine("Unknown argument {0}! Try [hack -h] for help with this tool.", args);
        }

        public void clear()
        {
            Console.Clear();
        }

        public bool ping(string address)
        {
            bool condition = false;
            try
            {
                if (Directory.Exists(AI.saveFolder() + address))
                {
                    condition = true;
                    Animation.pingAnimation(address, condition);
                    Player.Xp += Player.Xp*0.2;
                    return condition;
                }
                else
                    condition = false;
                    Animation.pingAnimation(address, condition);
                    Player.Xp += Player.Xp*0.1;
                    return condition;
            }
            catch
            {
                Console.WriteLine("Ping Alert: Incorrect ip address!");
                return condition;
            }
        } 

        public void ping(string address, string arg)
        {
            if (arg == "-h")
            {
                Console.WriteLine("");
                Console.WriteLine("================ Ping Help ================");
                Console.WriteLine("-h        | Brings up help menu");
                Console.WriteLine("ping <ip> | pings for existance of ip");
                Console.WriteLine("");
                Console.WriteLine("Ping tool is used to check if ip is online");
                Console.WriteLine("===========================================");
                Console.WriteLine("");
            }
            else
            Console.WriteLine("Unknown argument {0}! Try [ping -h] for help with this tool.", arg);
        }

        public void instruct()
        {
            Console.WriteLine("=============== Welcome to HaxNET ===============");
            Console.WriteLine("Welcome to HaxNET!");
            Console.WriteLine("");
            Console.WriteLine("Here, as a hacker, you will be able to test your");
            Console.WriteLine("skill at exploiting other machines on the HaxNET");
            Console.WriteLine("network. Collect bitcoins and use them to upgrade");
            Console.WriteLine("your tools and security. Be careful, however, as");
            Console.WriteLine("other users will attemp to steal your bitcoins!");
            Console.WriteLine("Have fun and enjoy the simulation!");
            Console.WriteLine("");
            Console.WriteLine("Nathan Bunch, CEO AVEVA GAMES");
            Console.WriteLine("=================================================");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue....");
            string tutorialTemp = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=============== Tutorial ===============");
            Console.WriteLine("");
            Console.WriteLine("<YOURUSERNAME>@hax.net > ");
            Console.WriteLine("");
            Console.WriteLine("This is the command propmt, enter in");
            Console.WriteLine("commands here.");
            Console.WriteLine("(just type in a command and hit enter)");
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue....");
            tutorialTemp = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=============== Tutorial ===============");
            Console.WriteLine("");
            Console.WriteLine("help");
            Console.WriteLine("");
            Console.WriteLine("THE most useful command in this entire");
            Console.WriteLine("program, the help command. This command");
            Console.WriteLine("will display a special menu that shows");
            Console.WriteLine("either a list of runnable programs or");
            Console.WriteLine("sub-commands within a running program.");
            Console.WriteLine("");
            Console.WriteLine("Note: Most programs have this command.");
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue....");
            tutorialTemp = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=============== Tutorial ===============");
            Console.WriteLine("This finishes up the tutorial.");
            Console.WriteLine("Have fun hacking!");
            Console.WriteLine("");
            Console.WriteLine("If you would like more detailed instructions");
            Console.WriteLine("please visit this link below to download");
            Console.WriteLine("the user's manual:");
            Console.WriteLine("");
            Console.WriteLine("https://drive.google.com/file/d/0B6vUmVOpfeg_bjNERjktcFp5WGc/view");
            Console.WriteLine("");
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue....");
            tutorialTemp = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter [help] to get started.");
        }

        public void displayBitcoins()
        {
            Console.WriteLine("");
            Console.WriteLine("========================================================");
            Console.WriteLine("               Account info for [{0}]", Player.PlayerName);
            Console.WriteLine("Account Num: [{0}]", Player.IpAddress);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Amount in storage: {0} bitcoins", Player.Bitcoin);
            Console.WriteLine("========================================================");
            Console.WriteLine("");
        }

        public void version()
        {
            Console.WriteLine("");
            Console.WriteLine("HaxNET Version: {0} | [SKYNET]", haxnetVersion);
            Console.WriteLine("");
        }

        public void scan()
        {
            Animation.scanAnimation(Player.Scanner);
            if (Player.Viruses > 0)
            {
                Console.WriteLine("[{0}] Viruses Found!", Player.Viruses);
                Console.Write("Do you wish to remove them now? [y/n]: ");
                string virusRemove = Console.ReadLine();
                if (virusRemove == "y")
                {
                    Animation.scanRemoveAnimation(Player.Viruses);
                    Player.Viruses = 0;
                }
                else
                if (virusRemove == "n")
                {

                }
                else
                    Console.WriteLine("Incorrect char entered!");
            }
            else
                Console.WriteLine("No viruses found!");
        }

        public void connect(string arg)
        {
            if (arg == "blacknet")
            {
                Console.WriteLine("Welcome to BlackNet!");
                Console.WriteLine("Loading product(s).....");
                for (int i = 0; i <= Animation.defaultTime / Player.UpSpeed; i++)
                {
                }
                int scannerPrice = Convert.ToInt32((Player.Scanner + 1.0) * 49.99);
                int firewallPrice = Convert.ToInt32((Player.Firewall + 1.0) * 49.99);
                int crackerPrice = Convert.ToInt32((Player.Cracker + 1.1) * 49.99);
                int upSpeedPrice = Convert.ToInt32((Player.UpSpeed + 0.8) * 49.99);
                int downSpeedPrice = Convert.ToInt32((Player.Downspeed + 1.3) * 49.99);
                double scannerUpgrade = Player.Scanner + 1.0;
                double firewallUpgrade = Player.Firewall + 1.0;
                double crackerUpgrade = Player.Cracker + 1.1;
                double upspeedUpgrade = Player.UpSpeed + 0.8;
                double downspeedUpgrade = Player.Downspeed + 1.3;
                while(true)
                {
                    Console.WriteLine("Your bitcoins: {0} bitcoins", Player.Bitcoin);
                    Console.WriteLine("==================== BlackNet Market ====================");
                    Console.WriteLine("Tools:");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("1: Hack Tool Version {0}            | {1} bitcoins", crackerUpgrade, crackerPrice);
                    Console.WriteLine("2: Firewall Upgrade {0}             | {1} bitcoins", firewallUpgrade, firewallPrice);
                    Console.WriteLine("3: Virus Scanner Upgrade {0}        | {1} bitcoins", scannerUpgrade, scannerPrice);
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("Internet Overclocks:");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("4: Download Overclock Version {0}   | {1} bitcoins", downspeedUpgrade, downSpeedPrice);
                    Console.WriteLine("5: UpLoad Over Clock Version {0}    | {1} bitcoins", upspeedUpgrade, upSpeedPrice);
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("6: Nothing (exit BlackNet Market)");
                    Console.WriteLine("=========================================================");
                    Console.Write("Which item would u like to purchase? [1,2,3,4,5]: ");
                    string blacknetOption = Console.ReadLine();
                    if (blacknetOption == "1")
                    {
                        if (Player.Bitcoin >= crackerPrice)
                        {
                            Console.WriteLine("Thankyou for your purchase!");
                            Player.Bitcoin -= crackerPrice;
                            Player.savePlayer();
                            Animation.downloadAnimation("Hack Tool Version " + (crackerUpgrade), Player.Downspeed);
                            Player.Xp += 0.5;
                            Player.Cracker += crackerUpgrade;
                            Player.savePlayer();
                        }
                    }
                    else
                    if (blacknetOption == "2")
                    {
                        if (Player.Bitcoin >= firewallPrice)
                        {
                            Console.WriteLine("Thankyou for your purchase!");
                            Player.Bitcoin -= firewallPrice;
                            Player.savePlayer();
                            Animation.downloadAnimation("Firewall Upgrade " + (firewallUpgrade), Player.Downspeed);
                            Player.Xp += 0.5;
                            Player.Firewall += firewallUpgrade;
                            Player.savePlayer();
                        }
                    }
                    else
                    if (blacknetOption == "3")
                    {
                        if (Player.Bitcoin >= scannerPrice)
                        {
                            Console.WriteLine("Thankyou for your purchase!");
                            Player.Bitcoin -= scannerPrice;
                            Player.savePlayer();
                            Animation.downloadAnimation("Virus Scanner Upgrade " + (scannerUpgrade), Player.Downspeed);
                            Player.Xp += 0.5;
                            Player.Scanner += scannerUpgrade;
                            Player.savePlayer();
                        }
                    }
                    else
                    if (blacknetOption == "4")
                    {
                        if (Player.Bitcoin >= downSpeedPrice)
                        {
                            Console.WriteLine("Thankyou for your purchase!");
                            Player.Bitcoin -= downSpeedPrice;
                            Player.savePlayer();
                            Animation.downloadAnimation("Download Overclock Version " + (downspeedUpgrade), Player.Downspeed);
                            Player.Xp += 0.5;
                            Player.Downspeed += downspeedUpgrade;
                            Player.savePlayer();
                        }
                    }
                    else
                    if (blacknetOption == "5")
                    {
                        if (Player.Bitcoin >= upSpeedPrice)
                        {
                            Console.WriteLine("Thankyou for your purchase!");
                            Player.Bitcoin -= upSpeedPrice;
                            Player.savePlayer();
                            Animation.downloadAnimation("Upload Overclock Version " + (upspeedUpgrade), Player.Downspeed);
                            Player.Xp += 0.5;
                            Player.UpSpeed += upspeedUpgrade;
                            Player.savePlayer();
                        }
                    }
                    else
                    if (blacknetOption == "6")
                    {
                        Console.WriteLine("Thank you for visiting the BlackNet Market!");
                        break;
                    }
                    else
                        Console.WriteLine("We are sorry, but that item is unavailable.");
                }
            }
            else
            if (arg == "micronoft")//micronoft store
            {
                Console.WriteLine("Welcome to the Micronoft Store!");
                Console.WriteLine("Loading product(s).....");
                for (int i = 0; i <= Animation.defaultTime / Player.UpSpeed; i++)
                {
                }
                int fullOsPrice;
                int halfOsPrice;
                while (true)
                {
                    fullOsPrice = Convert.ToInt32((Player.OperatingSystem + 1.0) * 149.99);
                    halfOsPrice = Convert.ToInt32((Player.OperatingSystem + 0.5) * 79.99);
                    Console.WriteLine("Your bitcoins: {0} bitcoins", Player.Bitcoin);
                    Console.WriteLine("===================== Products =====================");
                    Console.WriteLine("1: Full OS Version {0} | {1} bitcoins", Player.OperatingSystem + 1.0, fullOsPrice);
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("2: Part OS Version {0} | {1} bitcoins", Player.OperatingSystem + 0.5, halfOsPrice);
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("3: None (Exit Micronoft Store");
                    Console.WriteLine("====================================================");
                    Console.Write("Which would you like to purchase? [1,2,3]: ");
                    string micronoftOption = Console.ReadLine();
                    if (micronoftOption == "1")
                    {
                        if (Player.Bitcoin >= fullOsPrice)
                        {
                            Console.WriteLine("Thankyou for your purchase!");
                            Player.Bitcoin -= fullOsPrice;
                            Player.savePlayer();
                            Animation.downloadAnimation("Full OS Version " + (Player.OperatingSystem + 1.0), Player.Downspeed);
                            Player.Xp += 0.5;
                            Animation.upgradeOperatingSystem(Player.OperatingSystem + 1.0);
                            Player.OperatingSystem += 1.0;
                            Player.Firewall += 1.5;
                            Player.UpSpeed += 0.1;
                            Player.Downspeed += 0.5;
                            Player.Scanner += 0.5;
                            Player.savePlayer();
                        }
                        else
                        Console.WriteLine("We are sorry but you seem to not have enough bitcoins to complete this purchase.");
                        Console.WriteLine("Full OS Version Price: {0} bitcoins", fullOsPrice);
                        Console.WriteLine("Your bitcoins: {0} bitcoins", Player.Bitcoin);
                    }
                    else
                    if (micronoftOption == "2")
                    {
                        if (Player.Bitcoin >= halfOsPrice)
                        {
                            Console.WriteLine("Thankyou for your purchase!");
                            Player.Bitcoin -= halfOsPrice;
                            Player.savePlayer();
                            Animation.downloadAnimation("Part OS Version " + (Player.OperatingSystem + 0.5), Player.Downspeed);
                            Player.Xp += 0.25;
                            Animation.upgradeOperatingSystem(Player.OperatingSystem + 0.5);
                            Player.OperatingSystem += 0.5;
                            Player.Firewall += 1.0;
                            Player.UpSpeed += 0.05;
                            Player.Downspeed += 0.25;
                            Player.Scanner += 0.25;
                            Player.savePlayer();
                        }
                        else
                        Console.WriteLine("We are sorry but you seem to not have enough bitcoins to complete this purchase.");
                        Console.WriteLine("Part OS Version Price: {0} bitcoins", halfOsPrice);
                        Console.WriteLine("Your bitcoins: {0} bitcoins", Player.Bitcoin);
                    }
                    else
                    if (micronoftOption == "3")
                    {
                        Console.WriteLine("Thank you for visiting the Micronoft Store!");
                        break;
                    }
                    else
                        Console.WriteLine("We are sorry but that product number is unavailable.");
                }
            }
            else
            if (arg == "-h")
            {
                Console.WriteLine("");
                Console.WriteLine("============= Connect Tool Help =============");
                Console.WriteLine("connect <arg>       | Connect to <arg>");
                Console.WriteLine("        <blacknet>  | Connect to blacknet, ");
                Console.WriteLine("                      the place where you can");
                Console.WriteLine("                      purchase upgrades for");
                Console.WriteLine("                      your hacking tools");
                Console.WriteLine("        <micronoft> | Connect to the Micronoft");
                Console.WriteLine("                      store and buy new OS ");
                Console.WriteLine("                      upgrades");
                Console.WriteLine("=============================================");
                Console.WriteLine("");
            }
            else
                Console.WriteLine("Unknown argument {0}! Try [connect -h] for help wth this tool.");
        }

        public void pcStatus()
        {
            Player.RefreshHud();
        }

        public void aboutPC()
        {
            Console.WriteLine("");
            Console.WriteLine("================About this PC===================");
            Console.WriteLine("|HaxNET OS Version: {0}", Player.OperatingSystem);
            Console.WriteLine("|PassCrack Version: {0}", Player.Cracker);
            Console.WriteLine("|VirusTerminator Version: {0}", Player.Scanner);
            Console.WriteLine("|WebProtect Version: {0}", Player.Firewall);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("|Download Speeds: {0}", Player.Downspeed);
            Console.WriteLine("|Upload Speeds: {0}", Player.UpSpeed);
            Console.WriteLine("================================================");
            Console.WriteLine("");
        }

        public void aboutUser()
        {
            Console.WriteLine("");
            Console.WriteLine("=============== About: [{0}] ==================", Player.PlayerName);
            Console.WriteLine("|Current User Status: {0}", Player.PlayerTitle);
            Console.WriteLine("|User Experience Rating: {0}", Player.Xp);
            Console.WriteLine("|Connection Status: {0}", Player.ConnectionStatus);
            Console.WriteLine("==============================================");
            Console.WriteLine("");
        }

        public void resetAll()
        {
            Console.Clear();
            Console.Write("Are you sure you wish to reset this game (all saves will be deleted, all progress reset to 0)? [y/n]: ");
            string temp = Console.ReadLine();
            if (temp == "y")
                GameInstance.resetAll();
            else
                if (temp == "n")
                Console.WriteLine("ok");
            else
                Console.WriteLine("Incorrect answer!");
        }

        public void saveLocationOpen()
        {
            Process.Start(@Directory.GetCurrentDirectory());
        }

        public void volumeInfo()
        {
            Console.WriteLine("");
            Console.WriteLine("Volume in drive HaxNet.Virtual has label: [hnet]");
            Console.WriteLine("Volume Serial: AH20-72-913");
            Console.WriteLine("Volume [hnet] has: {0}KB free of {1}KB (using {2}KB)", 14357897846 - Convert.ToUInt64((Player.toolsSizeAverage()) * 5), 14357897846, Player.toolsSizeAverage() * 5);
            Console.WriteLine("");
        }//display how much virtual disk space the user is using

        public void gameExit()//exit the game
        {
            Player.savePlayer();
            GameInstance.close();
        }

        public void netscan()
        {
            Console.WriteLine("==================== NETSCAN ====================");
            Console.WriteLine("Computer(s) on the network:");
            int temp = GameInstance.randomNumber(3, 10);
            string ip;
            string ipLocation;
            for (int i = 0; i < temp; i++)
            {
                ip = GameInstance.ipGenerator();
                ipLocation = aiSaveLocation + "/" + ip + "/";
                if (Directory.Exists(ipLocation))
                {
                    Console.WriteLine(ip + "|..........|FireWall Level: " + AIManager.aiFirewallLevel(ipLocation));
                }
                else
                    AIManager.generateAI(ip);
                    Console.WriteLine(ip + "|..........|FireWall Level: " + AIManager.aiFirewallLevel(ipLocation));
            }
            Console.WriteLine("");
        }//scan network for ip addresses, if found new ip create new ai with that ip

        public void action(string action)//handle normal commands
        {
            if (action == "help")
                help();
            else
                if (action == "tree")
                dir();
            else
                if (action == "clear" || action == "clr")
                clear();
            else
                if (action == "tutorial")
                instruct();
            else
                if (action == "mscan")
                scan();
            else
                if (action == "pcstatus")
                pcStatus();
            else
                if (action == "about")
                aboutPC();
            else
                if (action == "whoami")
                aboutUser();
            else
                if (action == "resetall")
                resetAll();
            else
                if (action == "datetime")
                Console.WriteLine(DateTime.Now);
            else
                if (action == "hud")
                Player.RefreshHud();
            else
                if (action == "vol")
                volumeInfo();
            else
                if (action == "exit")
                gameExit();
            else
                if (action == "netscan")
                netscan();
            else
                if (action == "account")
                displayBitcoins();
            else
                if (action == "ver")
                version();
            else
                if (action == "savelocation")
                saveLocationOpen();
            else
                if (action == "?")
                help();
            else
                if (action == "ls")
                help();
            else
                Console.WriteLine("Incorrect command entered! (for help type [help])");

        }

        public void action(string action, string argument)//handle commands with one argument
        {
            if (action == "connect")
            {
                connect(argument);
            }
            else
            if (action == "ping")
            {
                if (argument == "-h")
                {
                    ping("1", argument);
                }
                string[] commandArgs = argument.Split('.');//send ip to array for analysis
                var e = from s in commandArgs
                        select s;
                int c = e.Count();
                try
                {
                    for (int i = 0; i < c; i++)
                    {
                        int block = Convert.ToInt32(commandArgs[i]);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Ping({0}) returns {1}", argument, ping(argument));
                    Console.WriteLine("");
                }
                catch
                {
                    Console.WriteLine("Incorrect ip address entered! ({0})", argument);
                    Console.WriteLine("For help with this command type: [ping -h]");
                }
            }
            else
            if (action == "hack")
            {
                if (argument == "-h")
                {
                    hack("1", "-h");
                }
                string[] commandArgs = argument.Split('.');//send ip to array for analysis
                var e = from s in commandArgs
                        select s;
                int c = e.Count();
                try
                {
                    for (int i = 0; i < c; i++)
                    {
                        int block = Convert.ToInt32(commandArgs[i]);
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect ip address entered! ({0})", argument);
                    Console.WriteLine("For help with this command type: [hack -h]");
                }
                hack(argument);
            }

        }

    }
}
