using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaxNET___The_Hacking_Simulator
{
    class Filesystem//for emulating a virtual pc filesystem
    {
        private static int j;
        private static string creationTimeDate = "11/11/2015    09:35 PM    ";
        private static string file = "<FILE>    ";
        private static string direct = "<DIR>    ";
        private static string program = "<PROG>    ";
        private static string progExt = ".hexe";
        private static string sysFileExt = ".dlh";
        private static string bootExt = ".bootsect";
        private static string sysImageExt = ".imgh";
        private static string locateFiles = ".local";

        public static void Tree()
        {
            SystemFolder();
            UserFolder();
            ProgramFolder();
            MainFolder();
        }
        public static void SystemFolder()
        {
            Console.WriteLine(creationTimeDate + direct + "HaxNETOS");
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|");
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|----System64");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----haxnetos64" + sysImageExt);
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----resource" + locateFiles);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|----System32");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----haxnetos32" + sysImageExt);
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----resource" + locateFiles);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|");
            Console.WriteLine("|");
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|----Boot");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----Fonts");
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Arial" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Calibri" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Cambria Math" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Consolas" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Georgia" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Impact" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Micronoft Sans Serif" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Raavi" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Symbol" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Times New Roman" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Verdana" + sysFileExt);
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Wingdings" + sysFileExt);
            Console.WriteLine("|    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|    |----debug" + sysFileExt);
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----bootres64" + bootExt);
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----bootres32" + bootExt);
            Console.WriteLine("|");
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|----Drivers");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----x64");
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----Intel");
            Console.WriteLine("|    |    |    |");
            Console.WriteLine("|    |    |    |----Processors");
            Console.WriteLine("|    |    |    |    |");
            Console.WriteLine("|    |    |    |    |----Core" + sysFileExt);
            Console.WriteLine("|    |    |    |    |");
            Console.WriteLine("|    |    |    |    |----Pentium" + sysFileExt);
            Console.WriteLine("|    |    |    |    |");
            Console.WriteLine("|    |    |    |    |----Celeron" + sysFileExt);
            Console.WriteLine("|    |    |    |    |");
            Console.WriteLine("|    |    |    |    |----Xeon" + sysFileExt);
            Console.WriteLine("|    |    |    |    |");
            Console.WriteLine("|    |    |    |    |----M" + sysFileExt);
            Console.WriteLine("|    |    |    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|    |    |    |");
            Console.WriteLine("|    |    |    |");
            Console.WriteLine("|    |    |    |----Sound Adapters");
            Console.WriteLine("|    |    |    |    |");
            Console.WriteLine("|    |    |    |    |----Realtek" + sysFileExt);
            Console.WriteLine("|    |    |    |");
            Console.WriteLine("|    |    |    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|    |    |    |");
            Console.WriteLine("|    |    |    |----Internet Controllers");
            Console.WriteLine("|    |    |         |");
            Console.WriteLine("|    |    |         |----Wifi" + sysFileExt);
            Console.WriteLine("|    |    |         |");
            Console.WriteLine("|    |    |         |----LAN" + sysFileExt);
            Console.WriteLine("|    |    |         |");
            Console.WriteLine("|    |    |         |----Ethernet" + sysFileExt);
            Console.WriteLine("|    |    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |");
            Console.WriteLine("|    |    |----AMD");
            Console.WriteLine("|    |         |");
            Console.WriteLine("|    |         |----Emulated");
            Console.WriteLine("|    |              |");
            Console.WriteLine("|    |              |----Processor" + sysFileExt);
            Console.WriteLine("|    |              |");
            Console.WriteLine("|    |              |----AMDSound" + sysFileExt);
            Console.WriteLine("|    |              |");
            Console.WriteLine("|    |              |----InternetAdapter" + sysFileExt);
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|    |");
            Console.WriteLine("|    |----x32");
            Console.WriteLine("          |");
            Console.WriteLine("          |----Intel");
            Console.WriteLine("          |    |");
            Console.WriteLine("          |    |----Processors");
            Console.WriteLine("          |    |    |");
            Console.WriteLine("          |    |    |----Core" + sysFileExt);
            Console.WriteLine("          |    |    |");
            Console.WriteLine("          |    |    |----Pentium" + sysFileExt);
            Console.WriteLine("          |    |    |");
            Console.WriteLine("          |    |    |----Celeron" + sysFileExt);
            Console.WriteLine("          |    |    |");
            Console.WriteLine("          |    |    |----Xeon" + sysFileExt);
            Console.WriteLine("          |    |    |");
            Console.WriteLine("          |    |    |----M" + sysFileExt);
            Console.WriteLine("          |    |");
            Console.WriteLine("          |    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("          |    |");
            Console.WriteLine("          |    |----Sound Adapters");
            Console.WriteLine("          |    |    |");
            Console.WriteLine("          |    |    |----Realtek" + sysFileExt);
            Console.WriteLine("          |    |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("          |    |");
            Console.WriteLine("          |    |");
            Console.WriteLine("          |    |----Internet Controllers");
            Console.WriteLine("          |         |");
            Console.WriteLine("          |         |----Wifi" + sysFileExt);
            Console.WriteLine("          |         |");
            Console.WriteLine("          |         |----LAN" + sysFileExt);
            Console.WriteLine("          |         |");
            Console.WriteLine("          |         |----Ethernet" + sysFileExt);
            Console.WriteLine("          |");
            Console.WriteLine("          |");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("          |");
            Console.WriteLine("          |----AMD");
            Console.WriteLine("               |");
            Console.WriteLine("               |----Emulated");
            Console.WriteLine("                    |");
            Console.WriteLine("                    |----Processor" + sysFileExt);
            Console.WriteLine("                    |");
            Console.WriteLine("                    |----AMDSound" + sysFileExt);
            Console.WriteLine("                    |");
            Console.WriteLine("                    |----InternetAdapter" + sysFileExt);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
        }
        public static void UserFolder()
        {
            Console.WriteLine(creationTimeDate + direct + Player.PlayerName);
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|");
            Console.WriteLine("|----bitcoin" + sysFileExt);
            Console.WriteLine("|");
            Console.WriteLine("|----settings" + sysFileExt);
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|----usersave" + sysFileExt);
            Console.WriteLine("|");
            Console.WriteLine("|----" + Player.PlayerName + sysFileExt);
        }
        public static void ProgramFolder()
        {
            Console.WriteLine(creationTimeDate + direct + "Programs");
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|");
            Console.WriteLine("|----Bitcoin" + progExt);
            Console.WriteLine("|");
            Console.WriteLine("|----Connect" + progExt);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|");
            Console.WriteLine("|----DateTime" + progExt);
            Console.WriteLine("|");
            Console.WriteLine("|----Firewall" + progExt);
            Console.WriteLine("|");
            Console.WriteLine("|----Hack" + progExt);
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|----Mscan" + progExt);
            Console.WriteLine("|");
            Console.WriteLine("|----Netscan" + progExt);
            Console.WriteLine("|");
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine("|----Ping" + progExt);
            Console.WriteLine("|");
            Console.WriteLine("|----Vol" + progExt);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
        }
        public static void MainFolder()
        {
            Console.WriteLine("\\");
            Console.WriteLine(" |");
            Console.WriteLine(" |boot" + locateFiles);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine(" |");
            Console.WriteLine(" |command" + progExt + sysFileExt);
            Console.WriteLine(" |");
            Console.WriteLine(" |preboot" + progExt + sysFileExt);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine(" |");
            Console.WriteLine(" |startup" + progExt + sysFileExt);
            for (j = 0; j < Animation.defaultTime / 2; j++)
            {
            }
            Console.WriteLine(" |");
            Console.WriteLine(" |sysimage" + locateFiles);
            Console.WriteLine("");
        }
    }
}
