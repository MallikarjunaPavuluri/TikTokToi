using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokToi
{
    class Game
    {
        private static char[] board = new char[9] { '1','2','3',
                                                        '4','5','6',
                                                        '7','8','9'};

        public static void Display()
        {
            int i;
            for ( i=0; i < 9; i++)
            {
             
                
                    Console.Write("\t"+board[i]+"\t|");
                
             if((i+1)%3==0)
               {
                    Console.WriteLine("\n\t_________________________________________");
               }
            }
        }

        internal static void Reset()
        {
         for(int i=0;i<9;i++)
            {
                board[i] = ' ';
            }
        }

        public static bool  WinnerCheck()
        {
            
           if(HorizantalCheck()||VerticalCheck()||DigonalCheck())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool DigonalCheck()
        {
            if(board[0]==board[4]&&board[4]==board[8]&&board[4]!=' ')
            {
                return true;
            }
            else if(board[2] == board[4] && board[4] == board[6] && board[4] != ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool VerticalCheck()
        {
            if (board[0] == board[3] && board[3] == board[6] && board[0] != ' ')
            {
                return true;
            }
            else if (board[1] == board[4] && board[4] == board[7] && board[1] != ' ')
            {
                return true;
            }
            else if(board[2] == board[5] && board[5] == board[8] && board[2] != ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool HorizantalCheck()
        {
            if (board[0] == board[1] && board[1] == board[2] && board[0] != ' ')
            {
                return true;
            }
            else if (board[3] == board[4] && board[4] == board[5] && board[3] != ' ')
            {
                return true;
            }
            else if (board[6] == board[7] && board[7] == board[8] && board[6] != ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Add(int box,char item)
        {

            board[box-1] = item;
        }

        

        public static int CheckIndex(String s)
        {
            int n=0;
            while(!int.TryParse(s,out n)||!(n>0&&n<10)|| board[n - 1] == 'X' || board[n - 1] == 'O')
            {
                if (!(n > 0 && n < 10))
                {
                    Console.WriteLine("Invalid Index");
                    s = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Already Filled Enter Again");
                    s = Console.ReadLine();
                }
            }
            return n;
        }
    }
}
