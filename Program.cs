using Task17.Models;

namespace Task17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbStore dbstore = new DbStore();

            Book book = new Book("Samama", "Mama", 2004);
            Book book2 = new Book("Zulfiyya", "Zuzu", 2002);
            Book book3 = new Book("Sebuhi", "Sebiska", 2003);

            List<Book> addbooks = new List<Book>
            {
              new Book("Nigar", "Nigus",2000),
              new Book("Tofiq", "Tofik", 2001)
            };

            dbstore.AddRange(addbooks);
            dbstore.Add(book);
            dbstore.Add(book2);
            dbstore.Add(book3);
        }
    }
}