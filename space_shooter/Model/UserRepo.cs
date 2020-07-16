using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace space_shooter.Model
{
    //repository tpeace
    class UserRepo
    {
        MySqlConnection conn;

        public UserRepo()
        {
            conn = new MySqlConnection("server=localhost;Database=dbpbo19;Uid=root;SslMode=none");
        }

        public List<User> getAll()
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    string query = "select * from tpeace";
                    return conn.Query<User>(query).ToList();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<User> getOne(String a)
        {
            using (conn)
            {
                try
                {
                    string query = "select * from tpeace where username = '"+a+"'";
                    return conn.Query<User>(query).ToList();
                }
                finally
                {

                }
            }
            
        }

        public User insert(string username)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    List<User> lu = new List<User>();
                    lu = getOne(username);
                    if (lu.Count == 0)
                    {
                        string query = "insert into tpeace values('" + username + "',"+0+")";
                        conn.Execute(query);
                        return new User(username, 0);
                    }
                    return lu[0];
                }
                finally
                {
                    conn.Close();
                   
                }
            }
        }

        public void update(string a,int score)
        {
            try
            {
                conn.Open();
                
                string query = "update tpeace set peace = " + score + " where username = '" + a + "'";
                conn.Execute(query);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
