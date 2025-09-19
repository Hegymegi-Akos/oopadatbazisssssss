using MySql.Data.MySqlClient;
using OOP_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    internal class LIbrary : ISqlStatement
    {
        public List<object> GetALlData(string dbName)
        {
            List<object> books = new List<object>();
            Connect conn = new Connect(dbName);
            conn.Connnection.Open();
            string sql = "Select *From 'books'";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connnection);
            MySqlDataReader dr = cmd.ExecuteReader();   
            dr .Read();
            while (dr.Read())
            {
                var book = new
                {
                    id = dr.GetInt32("id"),
                    title = dr.GetString("title"),
                    author = dr.GetString ("author"),
                    releaseDate = dr.GetString("releaseDate")
                };
                books.Add(book);
            }
            conn.Connnection.Close();
            return books;
        }
    }
}
