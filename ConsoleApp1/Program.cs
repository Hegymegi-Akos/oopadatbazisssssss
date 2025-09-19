using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OOP_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MySqlConnection conn = new MySqlConnection("server=localhost; database=library; user=root; password=");
            //try{
            //    conn.Open();
            //    Console.WriteLine("Sikeres csatlakozás!");
            //}
            //catch (Exception ex){
            //    Console.WriteLine($"Csatlakozás sikertelen: {ex.Message}");
            //}
            //finally{
            //    conn?.Close();
            //}
            Console.WriteLine("Kérem az adatbázis nevét: ");
            string dbName = Console.ReadLine();
            Connect conn = new Connect(dbName);
        }
    }
}