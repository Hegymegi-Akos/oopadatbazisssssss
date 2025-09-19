using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_DB
{
    internal class Connect
    {
        public MySqlConnection Connnection;
        private string _host;
        private string _database;
        private string _user;
        private string _password;
        private string _connectionString;

        public Connect(string database)
        {
            _host = "localhost";
            _database = database;
            _user = "root";
            _password = "";

            _connectionString = $"SERVER={_host}; DATABASE={_database}; UID={_user}; PASSWORD={_password};SslMode=None";

            Connnection = new MySqlConnection(_connectionString);
            try
            {
                Connnection.Open();
                Console.WriteLine("Sikeres csatlakozás!");
                Connnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sikertelen csatlakozás: {ex.Message}");
            }
        }

    }
}