using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaxNET___The_Hacking_Simulator
{
    class Logic//handles all game logic
    {
        static Random logicNumber = new Random();
        public static bool chnaceOfSuccess(double crackerLevel, double fireWallLevel)
        {
            int num;
            double difference = fireWallLevel - crackerLevel;
            if (difference <= 4.0)
            {
                num = logicNumber.Next(1, 2);
                if (num == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            if (difference > 4.0)
            {
                if (difference <= 8.0)
                {
                    num = logicNumber.Next(1, 3);
                    if (num == 2)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                if (difference > 8.0)
                {
                    num = logicNumber.Next(1, 5);
                    if (num == 3)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }
        public static void aiLogic()
        {
            int dN = logicNumber.Next(1, 8);

            if (dN == 1 || dN == 7)//upload viruses
            {
                Player.Viruses += 1;
            }
            else
            if (dN == 2)//section 2: take 1/4 of user bitcoins
            {
                dN = logicNumber.Next(1, 8);
                if (dN == 1 || dN == 3 || dN == 5 || dN == 7)
                {
                    Player.Bitcoin -= Convert.ToInt32(Player.Bitcoin * 0.25);
                    Console.WriteLine("Warning: Potentially maliscious activity found in your account [#{0}]", Player.IpAddress);
                }
                else
                if (dN == 2 || dN == 4 || dN == 6)
                {
                    Player.Viruses += 1;
                }
                else
                    dN = 0;
            }
            else
            if (dN == 3)//section 3: take 1/2 of user bitcoins
            {
                dN = logicNumber.Next(1, 8);
                if (dN == 1 || dN == 3 || dN == 5)
                {
                    Player.Bitcoin -= Convert.ToInt32(Player.Bitcoin * 0.5);
                    Console.WriteLine("Warning: Potentially maliscious activity found in your account [#{0}]", Player.IpAddress);
                }
                else
                if (dN == 2 || dN == 4)
                {
                    Player.Viruses += 1;
                }
                else
                    dN = 0;
            }
            else
            if (dN == 4)//section 4: take 3/4 of user bitcoins
            {
                dN = logicNumber.Next(1, 8);
                if (dN == 1 || dN == 3)
                {
                    Player.Bitcoin -= Convert.ToInt32(Player.Bitcoin * 0.75);
                    Console.WriteLine("Warning: Potentially maliscious activity found in your account [#{0}]", Player.IpAddress);
                }
                else
                if (dN == 2)
                {
                    Player.Viruses += 1;
                }
                else
                    dN = 0;
            }
            else
            if (dN == 5)//section 5: take all of user bitcoins
            {
                dN = logicNumber.Next(1, 8);
                if (dN == 1)
                {
                    Player.Bitcoin = 0;
                    Console.WriteLine("Warning: Potentially maliscious activity found in your account [#{0}]", Player.IpAddress);
                }
                else
                    Player.Viruses += 1;
            }
            else
            if (dN == 6)
            {

            }
            else
                dN = 0;
        }//randomized logic for ai
    }
}
