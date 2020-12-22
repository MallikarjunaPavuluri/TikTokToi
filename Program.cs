using System;

namespace TikTokToi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tHey Welcome To InnRoad TIK TOk TOI Game:");
            Console.WriteLine("\t\t\t________________________________________\n\n");
            
            // Console.WriteLine("Select One 1.Login Or Create Account\n\t  2.Login As Guest ");
            Console.WriteLine("Currently We Are Working On DataBase Continue  Login As Guest");
            /* var index = Console.ReadLine();
             int n = 0;
             while (!(int.TryParse(index, out n)))
             {
                 Console.WriteLine("\t\t\tInvalid Selection Enter Again");
                 index = Console.ReadLine();
             }
             if (n == 2)
             {

                 GuestPlayer.GameStart();
             }
             else
             {
                 PlayersDetails.GameStart();
             } */
             GuestPlayer.GameStart();


        }
    }
}
