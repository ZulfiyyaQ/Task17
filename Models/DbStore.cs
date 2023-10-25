using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Task17.Models
{
    internal class DbStore
    { public List<Book> books = new List<Book>();
        public DbStore()
        {
            File.Create(@"C:\Users\ca.r214.05\Desktop\Task17\Files\book.json").Close();
        }

        private static void WriteToDb(List<Book> books )
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\ca.r214.05\Desktop\Task17\Files\book.json"))
            {
                string jsonbook = JsonConvert.SerializeObject(books);
                sw.WriteLine(books);
            }
           
        }
       
        private static List<Book> ReadFromDb()
        {
            string result;
            using (StreamReader sr = new StreamReader(@"C:\Users\ca.r214.05\Desktop\Task17\Files\book.json"))
            {
                result = sr.ReadToEnd();
            }
            var book = JsonConvert.DeserializeObject<List<Book>>(result);
            return book;
        }

        public  void Add(Book book)
        {
            List<Book> books = ReadFromDb();

            book.Id=Guid.NewGuid().ToString();

            books.Add(book);
            WriteToDb(books);
            
        }

        public  void AddRange(List<Book>addbooks)
        {
            List<Book> books = ReadFromDb();

            foreach (var book in books)
            {
                book.Id=Guid.NewGuid().ToString();
            }
            books.AddRange(addbooks);
            WriteToDb(books);

        }

        public void ShowBook(string id)
        {
            id = Console.ReadLine();
            List<Book> books = ReadFromDb();
            foreach (var book in books)
            {
                if(id==book.Id)
                {
                    Console.WriteLine($"Id {book.Id}  Name {book.Name}  Author {book.Author}  Published Year {book.Year} ");
                }
            }

        }
        public  void ShowAllBook(string id)
        {
            id = Console.ReadLine();
            List<Book> books = ReadFromDb();

            foreach (var book in books)
            {
                    Console.WriteLine($"Id {book.Id}  Name {book.Name}  Author {book.Author}  Published Year {book.Year} ");
            }

        }

        public void Remove(string id)
        {
            id = Console.ReadLine();
            List<Book> books = ReadFromDb();

            foreach (var book in books)
            {
                books.Remove(book);
            }
            WriteToDb(books);
        }

        public void Update (string id)
        {
            id=Console.ReadLine();
            List<Book> books = ReadFromDb();

            foreach (var book in books)
            {
                book.Name = "Updated";
            }
            WriteToDb(books);
        }
    }
}
