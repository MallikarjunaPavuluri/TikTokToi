using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TikTokToi
{
    static class PlayersDetails
    {
       private static  List<Player> Players = new List<Player>();
       private static Player LoginOrCreateAccount()
        {
            Console.WriteLine("\t\t\tEnter 1.LogIn\n\t\t\t      2.Create Account");

            var no=Console.ReadLine();
            int n=0;
            while (!(no.Length == 1) || (!int.TryParse(no, out n)) || !(n > 0 && n < 3))
            {
                Console.WriteLine("Invalid Data");
                no= Console.ReadLine();
            }


            if (n==1)
            {
                return Login();
            }
            else
            {
                return CreateAccount();
            }

        }
       

        public static Player CreateAccount()
        {
            Console.WriteLine("Enter Your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter User Id:");
            var idstr = Console.ReadLine();
            int id;
            while (!(idstr.Length == 3) || !(int.TryParse(idstr, out id)) || IdCheck(id))
            {
                Console.WriteLine("Invalid Id Or Already Taken Enter Any Other One");
                idstr = Console.ReadLine();
            }
            Console.WriteLine("Enter Password:");
            var pwdstr = Console.ReadLine();
            while(pwdstr.Length>10)
            {
                Console.WriteLine("PassWord Length Should Be Less Than Equal 10 Digits");
                pwdstr = Console.ReadLine();
            }
            Players.Add(new Player(id, pwdstr, name, 0, 0, 0));
            return Players[Players.Count-1];

        }

        public static Player Login()
        {
            Console.WriteLine("Enter 3 Digit Id:");

            var idstring = Console.ReadLine();
            int id = 0;

            while (!(idstring.Length == 3) || !(int.TryParse(idstring, out id))||!IdCheck(id))
            {
                Console.WriteLine("Invalid Id Enter Id Again");
            }
            Console.WriteLine("Enter Your Password:");

            var pwdstring = Console.ReadLine();
            
            while (  !PasswordCheck(pwdstring,id))
            {
                Console.WriteLine("Invalid Password Enter Id Again");
            }
            var details= (from c in Players
                    where c.Id==id && c.Password==pwdstring
                    select c);
            return details.First();



        }

        private static bool PasswordCheck(string pwdstring,int id)
        {
            var checkpwd = from c in Players
                          where c.Password == pwdstring && c.Id==id
                          select c.Id;
            if (checkpwd.Contains(id))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool IdCheck(int id)
        {
            var checkid = from c in Players
                          where c.Id == id
                          select c.Id;
            if (checkid.Contains(id))
            {
                return true;
            }
            else
            {
               return  false;
            }
        }

        public static  void GameStart()
        {
            int box = 0;

            Player P1 = LoginOrCreateAccount();
            Player P2 = LoginOrCreateAccount();

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
                        P1.Win++;
                        P2.Loss++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Winner Is {P2.Name}");
                        P2.Win++;
                        P1.Loss++;
                        break;
                    }
                }
                
                Game.Display();

            }
            if ((!Game.WinnerCheck()))
            {
                Console.WriteLine("Oh Match Draw");
                P1.Draw++;
                P1.Draw++;
            }

            Game.Display();

        }
    }
}
