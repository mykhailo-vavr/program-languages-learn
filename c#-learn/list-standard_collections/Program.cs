using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_standard_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Library libr = new Library();
            libr.ReadFromFile("data.txt");
            foreach (Book book in libr)
            {
                Console.WriteLine(book);
            }
            Dictionary<string, int> dict = libr.BooksCount();
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
        }
    }
}
