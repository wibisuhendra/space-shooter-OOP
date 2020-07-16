using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using space_shooter.Model;

namespace space_shooter.Controller
{
    class UserController
    {
        //controller yang mengatur jalannya data dari database 
        private string username;
        private int peace;
        private ListUser lu;

        public string Username { get => username; set => username = value; }
        public int Peace { get => peace; set => peace = value; }
        internal ListUser Lu { get => lu; set => lu = value; }

        public UserController(string name)
        {
            Username = name;
        }


        public UserController()
        {
            Lu = new ListUser();
        }

        //mengambil semua data
        public void getAll()
        {
            UserRepo ur = new UserRepo();
            Lu.User = ur.getAll();

        }

        //memasukan data sekaligus cek apakah username sudah ada
        public void insert()
        {
            UserRepo ur = new UserRepo();
            User user =  ur.insert(Username);
            this.Peace = user.Peace;
        }

        //update score peace ketika game selesai
        public void update()
        {
            UserRepo ur = new UserRepo();
            ur.update(Username, Peace);
        }

    }
}
