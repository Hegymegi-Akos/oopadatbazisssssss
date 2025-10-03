using MySql.Data.MySqlClient;
using OOP_D;
using System.Collections.Generic;

namespace OOPAdatbazis.Services
{
    internal class Library : ISqlStatements
    {
        public object AddNewItem(object newRecord)
        {
            Connect conn = new Connect("library");

            conn.Connection.Open();

            string sql = "INSERT INTO `books`(`title`, `author`, `releaseDate`) VALUES (@title,@author,@releaseDate)";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            var record = newRecord.GetType().GetProperties();
            cmd.Parameters.AddWithValue("@title", record[0].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@author", record[1].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@releaseDate", record[2].GetValue(newRecord));

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            var result = new
            {
                message = "Sikeres felvétel.",
                result = newRecord
            };

            return result;
        }

        public object DeleteItem(int id)
        {
            Connect conn = new Connect("library");

            conn.Connection.Open();

            string sql = "DELETE FROM `books` WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            var result = new
            {
                message = "Sikeres törlés.",

            };

            return result;
        }

        public List<object> GetAllData(string dbName)
        {
            Connect conn = new Connect(dbName);

            List<object> books = new List<object>();

            conn.Connection.Open();

            string sql = "SELECT * FROM `books` ";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            while (dr.Read())
            {
                var book = new
                {
                    id = dr.GetBodyDefinition(dr.GetName(0)),
                    title = dr.GetBodyDefinition(dr.GetName(1)),
                    author = dr.GetBodyDefinition(dr.GetName(2)),
                    releaseDate = dr.GetBodyDefinition(dr.GetName(3))
                };

                books.Add(book);
            }

            conn.Connection.Close();

            return books;
        }

        public object GetById(int id)
        {
            Connect conn = new Connect("library");

            conn.Connection.Open();

            string sql = "SELECT * FROM `books` WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            var record = new
            {
                id = dr.GetBodyDefinition(dr.GetName(0)),
                title = dr.GetBodyDefinition(dr.GetName(1)),
                author = dr.GetBodyDefinition(dr.GetName(2)),
                releaseDate = dr.GetBodyDefinition(dr.GetName(3))
            };

            conn.Connection.Close();

            return record;
        }

        public object UpdateIte(int id, object modifiedItem)
        {
            Connect conn = new Connect("library");

            conn.Connection.Open();

            string sql = "UPDATE `books` SET `title`=@title,`author`=@author, `releaseDate`=@rdate WHERE `id`=@id";

            var record = modifiedItem.GetType().GetProperties();

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            cmd.Parameters.AddWithValue("@title", record[0].GetValue(modifiedItem));
            cmd.Parameters.AddWithValue("@author", record[1].GetValue(modifiedItem));
            cmd.Parameters.AddWithValue("@rdate", record[2].GetValue(modifiedItem));

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            return new { message = "Sikeres módosítás." };
        }
    }
}
