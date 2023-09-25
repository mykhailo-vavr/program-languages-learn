using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace templates
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr_int = { 1, 2, 3, 4, 99, -99, 5, 6, 7, 8 };
            func<int>(arr_int);
            foreach(int item in arr_int)
            {
                Console.Write(item + " ");
            }

            string[] arr_string = { "zz", "aa", "bb", "cc" };
            func<string>(arr_string);
            foreach (string item in arr_string)
            {
                Console.Write(item + " ");
            }
        }

        public static void func<T>(T[] arr) where T: IComparable<T>
        {
            int index_max, index_min, i1, i2;
            /* T max = arr.Max();
             T min = arr.Min();
             index_max = Array.IndexOf(arr, max);
             index_min = Array.IndexOf(arr, min);*/

            T max, min;
            max = min = arr[0];
            index_max = index_min = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(max.CompareTo(arr[i]) < 0)
                {
                    max = arr[i];
                    index_max = i;
                }
                if(min.CompareTo(arr[i]) > 0)
                {
                    min = arr[i];
                    index_min = i;
                }
            }

            if(index_max > index_min)
            {
                i1 = index_min;
                i2 = index_max;
            } 
            else
            {
                i2 = index_min;
                i1 = index_max;
            }
            for (int i = i1 - 1; i >= 0; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[0] = max;
            for (int i = i2; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = min;
        }
    }
}
