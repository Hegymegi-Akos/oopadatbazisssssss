using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using OOP_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleApp1.Services
{
    internal class LIbrary : ISqlStatement
    {
        public object AddNewItem(object newRecord)
        {
            Connect conn = new Connect("library");

            conn.Connnection.Open();

            string sql = "INSERT INTO `books`(`title`, `author`, `releaseDate`) VALUES(@title, @author, @releasDate)";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connnection);

            cmd.ExecuteNonQuery();

            var record = newRecord.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@title", record[0].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@author", record[1].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@releaseDate", record[2].GetValue(newRecord));

            conn.Connnection.Close();

            var result = new
            {
                message = "sikeres felvétel",
                result = newRecord
            };
            return result;
        }

        public object DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

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

        public object GetById(int id)
        {
            Connect conn = new Connect("library");
            conn.Connnection.Open();

            string sql = $"SELECT * FROM 'books' WHERE id = @id ";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connnection);

            cmd.Parameters.AddWithValue("id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr .Read();

            var record = new
            {
                id = dr.GetInt32("id"),
                title = dr.GetString("title"),
                author = dr.GetString("author"),
                releaseDate = dr.GetString("releaseDate")
            };

            conn.Connnection.Close();
            return record;
        }

        public object UpateIte(int modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
