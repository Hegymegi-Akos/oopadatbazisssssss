using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace OOPAdatbazis.Services
{
    internal class Cars : ISqlStatements
    {
        public object AddNewItem(object newRecord)
        {
            throw new System.NotImplementedException();
        }

        public object DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<object> GetAllData(string dbName)
        {
            Connect conn = new Connect(dbName);

            List<object> cars = new List<object>();

            conn.Connection.Open();

            string sql = "SELECT * FROM `cars`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            while (dr.Read())
            {
                var car = new
                {
                    id = dr.GetBodyDefinition(dr.GetName(0)),
                    brand = dr.GetBodyDefinition(dr.GetName(1)),
                    type = dr.GetBodyDefinition(dr.GetName(2)),
                    mDate = dr.GetDateTime(dr.GetName(3))
                };

                cars.Add(car);
            }
            conn.Connection.Close();

            return cars;
        }

        public object GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public object UpdateIte(int id, object modifiedItem)
        {
            throw new NotImplementedException();
        }
    }
}
