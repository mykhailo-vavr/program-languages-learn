using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Lab_1
{
    public class Cars
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public DateTime CreationYear { get; set; }
        public int Price { get; set; }
        public Cars() { }
        public Cars(string br, string t, DateTime cr, int pr)
        {
            Brand = br;
            Type = t;
            CreationYear = cr;
            Price = pr;
        }
        /* public static bool TryParse(DataRow row, out Cars obj)
         {
             obj = new Cars();
             if (ValidateObject(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), out Cars o))
             {
                 obj = o;
                 return true;
             }
             return false;
         }
         public override string ToString()
         {
             return $"\n{Title} lectures {Surname} for {Hours} hours. Count of students {StudentsCount}";
         }
         public static bool ValidateObject(string a, string b, string c, string d, out Cars obj)
         {
             obj = new Cars();
             if (Validation.ValidateName(a) && Validation.ValidateName(b) && Validation.ValidateCount(c, out int res) && Validation.ValidateCount(d, out int count))
             {
                 obj = new Cars(a, b, res, count);
                 return true;
             }
             return false;
         }*/

        //  }

        /* public static class Validation
         {
             public static bool ValidateName(string name)
             {
                 if (name.Length == 0)
                     return false;

                 foreach (var character in name)
                 {
                     if (Char.IsDigit(character))
                         return false;
                 }
                 return true;
             }
             public static bool ValidateCount(string str, out int count)
             {
                 if (int.TryParse(str, out count))
                 {
                     if (count > 0)
                         return true;
                 }
                 return false;
             }*/
        /*public static bool ValidateReportingForm(string str)
        {
            string pattern = "^[0-9]{2}-[a-z]{2}$";

            if (str.Length == 5 && Regex.IsMatch(str, pattern))
            {
                return true;
            }
            return false;

        }*/
        /*   public static bool IsSimilarPrograms(Cars a, Cars b)
           {
               if (a.Title == b.Title && a.Surname == b.Surname)
                   return true;
               return false;
           }
           public static string is_correct_file()
           {
               Console.WriteLine("Input the file name:");
               string path = Path.GetFullPath(Console.ReadLine());
               if (!File.Exists(path))
               {
                   Console.WriteLine("This file does not exist! Try another one?");
                   is_correct_file();
               }
               return path;
           }*/
    }
}
