using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list_standard_collections
{
    class Book: IComparable<Book>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int Pages { get; set; }
        public Book () {}
        public Book(string n, string a, int p, int pg)
        {
            Name = n;
            Author = a;
            PublicationYear = p;
            Pages = pg;
        }
        public override string ToString()
        {
            return $"{Name} - {Author}, {PublicationYear}, {Pages}";
        }

        public int CompareTo(Book other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
