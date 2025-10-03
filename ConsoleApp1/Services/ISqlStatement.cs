using System.Collections.Generic;

namespace OOPAdatbazis.Services
{
    internal interface ISqlStatements
    {
        List<object> GetAllData(string dbName);
        object GetById(int id);

        object AddNewItem(object newRecord);

        object DeleteItem(int id);

        object UpdateIte(int id, object modifiedItem);
    }
}
