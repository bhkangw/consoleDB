using System;
using DbConnection;
using System.Collections.Generic;

namespace consoleDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowUsers();
            // NewUser();
        }
        static void ShowUsers()
        {
            List<Dictionary<string, object>> myQuery = new List<Dictionary<string, object>>();
            myQuery = DbConnector.Query("SELECT * FROM users");
            foreach(Dictionary<string, object> user in myQuery)
            {
                System.Console.WriteLine(user["FirstName"] + " " + user["LastName"] + ": " + user["FavoriteNumber"]);
            }
        }

        static void NewUser()
        {
            System.Console.WriteLine("What is your first name?");
            string fname = Console.ReadLine();
            System.Console.WriteLine("What is your last name?");
            string lname = Console.ReadLine();
            System.Console.WriteLine("What is your favorite number?");
            string number = Console.ReadLine();
            DbConnector.Execute($"INSERT INTO users (FirstName, LastName, FavoriteNumber) VALUES ('{fname}','{lname}',{number})");
        }


        // static void FindUser(int id)
        // {
        //     Dictionary<string, object> user = new Dictionary<string, object>();
        //     user = DbConnector.Query($"SELECT * FROM users WHERE id = {id}");
            
        // }
    }
}
