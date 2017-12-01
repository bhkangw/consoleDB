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
            UpdateUser();
        }
        static void ShowUsers()
        {
            List<Dictionary<string, object>> myQuery = new List<Dictionary<string, object>>();
            myQuery = DbConnector.Query("SELECT * FROM users");
            foreach(Dictionary<string, object> user in myQuery)
            {
                System.Console.WriteLine(user["id"] + ": " + user["FirstName"] + " " + user["LastName"] + " - " + user["FavoriteNumber"]);
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

        static void UpdateUser()
        {
            System.Console.WriteLine("Which user id would you like to update?");
            string id = Console.ReadLine();
            System.Console.WriteLine("Update first name to:");
            string fname = Console.ReadLine();
            DbConnector.Execute($"UPDATE users SET FirstName = '{fname}' WHERE id={id}");
            System.Console.WriteLine("Update last name to:");
            string lname = Console.ReadLine();
            DbConnector.Execute($"UPDATE users SET LastName = '{lname}' WHERE id={id}");
            System.Console.WriteLine("Update favorite number to:");
            string number = Console.ReadLine();
            DbConnector.Execute($"UPDATE users SET FavoriteNumber = '{number}' WHERE id={id}");
        }

        static void DeleteUser()
        {
            System.Console.WriteLine("Which user with you like to delete?");
            string id = Console.ReadLine();
            DbConnector.Execute($"DELETE FROM users WHERE id={id}");
        }

        // static void FindUser(int id)
        // {
        //     Dictionary<string, object> user = new Dictionary<string, object>();
        //     user = DbConnector.Query($"SELECT * FROM users WHERE id = {id}");
            
        // }
    }
}
