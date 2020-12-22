using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokToi
{
    class GuestPlayer 
    {
        public GuestPlayer(string name)
        {
            Name = name;
        }

        public String Name
        {
            get;
        }
        
        private static GuestPlayer Guest()
        {
            Console.WriteLine("Enter Your Name -");
            var name = Console.ReadLine();
            GuestPlayer p = new GuestPlayer(name);
            return p;
        }

        public static  void GameStart()
        {
            int box = 0;
            
            GuestPlayer P1 = Guest();

            GuestPlayer P2 = Guest();
            GuestPlayer Swap;
            Random coin = new Random();
            int toss = coin.Next(0, 2); 
            if(toss==1)
            {
                Console.WriteLine($"System Toss Winner is {P2.Name}");
                Swap = P1;
                P1 = P2;
                P2 = Swap;
                
            }
            else
            {
                Console.WriteLine($"System Toss Winner is {P1.Name}");
            }
            
            Game.Display();
            Game.Reset();
            var index = " ";

            for (int i = 0; i < 9; i++)
            {

                if (i % 2 == 0)
                {
                    Console.WriteLine($"\t\t\t{P1.Name} Enter Box No");
                    index = Console.ReadLine();
                    box = Game.CheckIndex(index);
                    Game.Add(box, 'X');

                }
                else
                {
                    Console.WriteLine($"\t\t\t{P2.Name} Enter Box No");
                    index = Console.ReadLine();
                    box = Game.CheckIndex(index);
                    Game.Add(box, 'O');

                }
                     if (i >= 4 && Game.WinnerCheck())
                     {
                         if (i % 2 == 0)
                         {
                             Console.WriteLine($"Winner Is {P1.Name}");
                             break;
                         }
                         else
                         {
                             Console.WriteLine($"Winner Is {P2.Name}");
                             break;
                         }
                     }
                Game.Display();

            }
            if ((!Game.WinnerCheck()))
            {
                Console.WriteLine("Oh Match Draw");
            }
            Game.Display();
        }
    }
}
