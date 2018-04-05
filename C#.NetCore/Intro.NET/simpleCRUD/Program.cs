using System;
using System.Collections.Generic;
using DbConnection;

namespace simpleCRUD
{
    class Program
    {
        public void Read(List<Dictionary<string,object>> userlist)
        {
            foreach (var users in userlist)
            {
                foreach (var user in users)
                {
                    System.Console.Write($"{user.Value} / ");
                }
                
            }
        }
        public void Create()
        {
            string firstname = Console.ReadLine();
            string lastname = Console.ReadLine();
            string favstr = Console.ReadLine();
            int favnum = Convert.ToInt32(favstr);
            DbConnector.Execute($"INSERT INTO users (FirstName,LastName,FavoriteNumber) VALUES ('{firstname}','{lastname}','{favnum}')");
        }
        static void Main(string[] args)
        {
            Program example = new Program();
            var userlist = DbConnector.Query("SELECT * FROM users");
            example.Read(userlist);
            example.Create();
            example.Read(userlist);
        }
    }
}
