using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task17.Models
{
    internal class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string name,string author,int year)
        {
            Name = name;
            Author = author;
            Year = year;
        }
    }
}
