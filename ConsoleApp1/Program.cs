using OOPAdatbazis.Services;
using System;

namespace OOPAdatbazis
{
    internal class Program
    {
        static void Main(string[] args)
        {


            ISqlStatements dataBase = new Library();

            Console.Write("Kérem a record id-jét:");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Kérem az uj title-t:");
            string title = Console.ReadLine();

            Console.Write("Kérem az uj author-t:");
            string auhor = Console.ReadLine();

            Console.Write("Kérem az uj releaseDate-et:");
            string rdate = Console.ReadLine();

            var book = new
            {
                Title = title,
                Author = auhor,
                ReleseDate = rdate
            };

            Console.WriteLine(dataBase.UpdateIte(id, book));


            /*Console.Write("Kérem az datbázis nevét: ");
            string dbName = Console.ReadLine();*/

            /*foreach (var item in dataBase.GetAllData(dbName))
            {
                var books = item.GetType().GetProperties();
                Console.WriteLine($"{books[0].Name}={books[0].GetValue(item)}, {books[1].Name}={books[1].GetValue(item)}");
            }*/

            /*Console.Write("Kérem a rekord id-jét: ");
            Console.WriteLine(dataBase.GetById(int.Parse(Console.ReadLine())));*/

            /*var book = new
            {
                title = "Star wars",
                author = "Lucas",
                releaseDate = "1980-01-01"
            };

            dataBase.AddNewItem(book);*/

            //Console.WriteLine(dataBase.DeleteItem(101));

        }
    }
}
