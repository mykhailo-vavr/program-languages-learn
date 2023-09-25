using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_I_Comparable_IClonable_etc_
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Bruno", "Avilio");

            for (int i = 0; i < 5; i++)
            {
                student1[i] = i + 2;
            }

            Student student2 = (Student)student1.Clone();
            student2.Surname = "Shinomiya";

            //Console.WriteLine(student1);
            //Console.WriteLine(student2);

            //////

            /* Student[] arr = new Student[2];
             arr[0] = student1;
             arr[1] = student2;

             Array.Sort(arr);

             foreach (Student student in arr) 
             {
                 Console.WriteLine(student);
             }*/

            //////

            Collection group = new Collection("PMI-23");
            group.ReadFromFile("../../data.txt");

            group.SortByAverage();
            //group.SortByAlphabetic();
            foreach (Student student in group)
            {
                if (student != null)
                    Console.WriteLine(student);
            }
        }
    }
}
