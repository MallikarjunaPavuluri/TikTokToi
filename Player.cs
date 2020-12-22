using System;
using System.Collections.Generic;
using System.Text;

namespace TikTokToi
{
    class Player
    {
        

        public Player(int id, string pwdstr, string name, int v1, int v2, int v3)
        {
            Id = id;
            Password = pwdstr;
            Name = name;
            Win = v1;
            Loss = v2;
            Draw= v3;
        }

        public String Name
        {
            get;
        }
        public int Id
        {
            get;
        }
        public String Password
        {
            get;
        }
        public int Win
        {
            get;
            set;
        }
        public int Loss
        {
            get;
            set;
        }
        public int Draw
        {
            get;
            set;
        }
        
    }
}
