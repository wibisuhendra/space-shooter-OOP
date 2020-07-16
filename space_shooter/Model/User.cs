using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_shooter.Model
{
    //model dari table tpeace
    class User
    {
        private string username;
        private int peace;

        public string Username { get => username; set => username = value; }
        public int Peace { get => peace; set => peace = value; }
        
        public User(string name,int score)
        {
            username = name;
            peace = score;
        }

        public User()
        {

        }
        
    }
}
