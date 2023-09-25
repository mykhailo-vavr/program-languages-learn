using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace list_standard_collections
{
    class Library: IEnumerable<Book>
    {
        public string LibraryName { get; set; }
        List<Book> books = new List<Book>();

        public void add(Book book)
        {
            books.Add(book);
        }

        public void ReadFromFile(string filename)
        {
            using(StreamReader sr = new StreamReader("../../" + filename))
            {
                while(!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split();
                    Book book = new Book(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]));
                    books.Add(book);
                }
            }
        }
        public void Sort()
        {
            books.Sort();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Dictionary<string, int> BooksCount()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (Book b in books)
            {
                if(dict.ContainsKey(b.Author))
                {
                    dict[b.Author]++;
                }
                else
                {
                    dict.Add(b.Author, 1);
                }
            }
            return dict;
        }
        // 1 і 2 - методи для створення HashSet із Library

        // 1
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        // 2
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        static HashSet<Book> GetCommonBoks(Library l1, Library l2)
        {
            HashSet<Book> books1 = new HashSet<Book>(l1.books);
            HashSet<Book> books2 = new HashSet<Book>(l2.books);
            books1.IntersectWith(books2);
            return books1;
        }
    }
}
