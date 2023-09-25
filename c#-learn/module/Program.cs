using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace module
{
    class Book : IComparable<Book>
    {
        private double price;
        private int countOfBooks;

        public string Name { get; set; }
        public double Price { 
            get {
                return price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price should be > 0");
                }
                price = value;
            }
        }
        public int CountOfBooks { 
            get
            {
                return countOfBooks;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Count of books should be > 0");
                }
                countOfBooks = value;
            }
        }
        public Book() {}
        public Book(string name, double price, int countOfBooks)
        {
            Name = name;
            Price = price;
            CountOfBooks = countOfBooks;
        }
        public override string ToString()
        {
            return $"{Name} - {Price}, {CountOfBooks}";
        }
        public int CompareTo(Book other)
        {
            return Name.CompareTo(other.Name);
        }
    }
    class TechnicalBook : Book {
        public string Field { get; set; }
        public  TechnicalBook(): base() {}
        public TechnicalBook(string name, double price, int countOfBooks, string field): base(name, price, countOfBooks)
        {
            Field = field;
        }
        public override string ToString()
        {
            return base.ToString() + "; Technical book";
        }
    }
    class ArtBook : Book
    {
        public string Genre { get; set; }
        public ArtBook() : base() { }
        public ArtBook(string name, double price, int countOfBooks, string genre) : base(name, price, countOfBooks)
        {
            Genre = genre;
        }
        public override string ToString()
        {
            return base.ToString() + "; Art book";
        }
    }
    class Shop: IComparable<Shop>
    {
        public string ShopName { get; set; }
        List<Book> books = new List<Book>();
        public void add(Book book)
        {
            books.Add(book);
        }

        public void ReadFromFile(string filename)
        {
            try { 
                using (StreamReader sr = new StreamReader("../../" + filename))
                {
                    ShopName = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split();
                        if(int.Parse(fields[0]) == 1)
                        {
                            Book book = new TechnicalBook(fields[1], double.Parse(fields[2]), int.Parse(fields[3]), fields[4]);
                            books.Add(book);
                        }
                        else if(int.Parse(fields[0]) == 2)
                        {
                            Book book = new ArtBook(fields[1], double.Parse(fields[2]), int.Parse(fields[3]), fields[4]);
                            books.Add(book);
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public void Sort()
        {
            books.Sort();
        }
        public void ShowBooks()
        {
            Console.WriteLine($"Shop name: {ShopName}");
            foreach(Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("");
        }
        public void ShowSortedBooks()
        {
            Sort();
            ShowBooks();
        }
        public double GetGeneralSum()
        {
            double sum = 0;
            foreach (Book book in books)
            {
                sum += book.Price;
            }
            return sum;
        }
        public int CountOfArtBook()
        {
            int count = 0;
            foreach (Book book in books)
            {
                if(book.GetType() == typeof(ArtBook))
                {
                    count++;
                }
            }
            return count;
        }
        public bool ContainBook(string name)
        {
            foreach(Book book in books)
            {
                return book.Name == name;
            }
            return false;
        }
        public double BookPrice(string name)
        {
            foreach (Book book in books)
            {
                if(book.Name == name)
                {
                    return book.Price;
                }
            }
            return -1;
        }
        public int CompareTo(Shop other)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shop shop1 = new Shop();
            shop1.ReadFromFile("data1.txt");

            Shop shop2 = new Shop();
            shop2.ReadFromFile("data2.txt");

            List<Shop> shops = new List<Shop>();
            shops.Add(shop1);
            shops.Add(shop2);

            // Список книг впорядкований за назвою
            Console.WriteLine("Task 1:");

            foreach (Shop shop in shops)
            {
                shop.ShowSortedBooks();
            }
            Console.WriteLine("");

            // Обчислити сумарну вартість книжок по кожному магазину,
            // інформацію зберегти в колекцію Dictionary.
            Console.WriteLine("Task 2:");

            Dictionary<string, double> dict = new Dictionary<string, double>();
            foreach (Shop shop in shops)
            {
                if (dict.ContainsKey(shop.ShopName))
                {
                    dict[shop.ShopName] += shop.GetGeneralSum();
                }
                else
                {
                    dict.Add(shop.ShopName, shop.GetGeneralSum());
                }
            }
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            // Для заданого магазину обчислити загальну кількість
            // книг художньої літератури.
            Console.WriteLine("Task 3:");

            Console.WriteLine($"Count of art books in {shop1.ShopName}: {shop1.CountOfArtBook()}");

            // Вивести перелік назв магазинів, у яких продається задана книга,
            // впорядкувавши магазини за спаданням вартості цієї книги.
            Console.WriteLine("Task 4:");

            string bookName = "specialBook";
            Dictionary<string, double> shopWithSpecificBook = new Dictionary<string, double>();
            foreach (Shop shop in shops)
            {
                if (shop.ContainBook(bookName))
                {
                    dict.Add(shop.ShopName, shop.BookPrice(bookName));
                }
            }
            var sortedShopWithSpecificBook = from entry in shopWithSpecificBook orderby entry.Value ascending select entry;
            
        }
    }

    
}
