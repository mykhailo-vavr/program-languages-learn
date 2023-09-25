using System;
// C:\Users\ElitexAdmin\Desktop\hotels.json
namespace Hotel
{
    class MainClass
    {
        private static void read_txt_file(LstCollection l)
        {
            Console.WriteLine("Enter path: ");
            var file = Console.ReadLine();
            l.ReadJsonFile(file);
        }

        private static void sort_elements(LstCollection l)
        {
            Console.WriteLine("Sort query: \n");
            l.Sort(Console.ReadLine());
        }

        private static void search_elements(LstCollection l)
        {
            Console.WriteLine("Search query: \n");
            var res = new LstCollection(l.Search(Console.ReadLine()));
            Console.WriteLine(res);
        }

        private static void add_elements(LstCollection l)
        {
            var p = new Hotel();
            p.InputProduct();
            l.AddItem(p);
        }

        private static void del_element(LstCollection l)
        {
            Console.WriteLine("Enter id to delete: ");
            l.Delete(Console.ReadLine());
        }

        private static void edit_element(LstCollection l)
        {
            Console.Write("Enter id to edit: ");
            var id = Console.ReadLine();
            Console.Write("Enter field to edit: ");
            var atter = Console.ReadLine();
            Console.Write("Enter value to change: ");
            var value = Console.ReadLine();
            l.Edit(id, atter, value);
        }

        private static string get_help_message()
        {
            string helpMessage =
                "\n  1) read from file" +
                "\n  2) sort elements" +
                "\n  3) search element" +
                "\n  4) add Hotel to collection" +
                "\n  5) to del element from collection" +
                "\n  6) edit element from collection" +
                "\n  7) show collection" +
                "\n  exit) exit" + "\n";
            return helpMessage;
        }

        public static void Main(string[] args)
        {
            LstCollection l = new LstCollection();
            while (true)
            {
                Console.WriteLine(get_help_message());
                string task = Console.ReadLine();
                switch (task)
                {
                    case "1":
                        read_txt_file(l);
                        break;
                    case "2":
                        sort_elements(l);
                        break;
                    case "3":
                        search_elements(l);
                        break;
                    case "4":
                        add_elements(l);
                        break;
                    case "5":
                        del_element(l);
                        break;
                    case "6":
                        edit_element(l);
                        break;
                    case "7":
                        if (l.Length() >= 0)
                            Console.WriteLine(l);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("error");
                        continue;
                }
                Console.WriteLine();
            }
        }
    }
}