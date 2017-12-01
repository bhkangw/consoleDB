using System;
using DbConnection;

namespace consoleDB
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = DbConnector.Query("SELECT * FROM users");
            foreach (var user in users)
            {
                System.Console.WriteLine(user);
            }
        }
    }
}
