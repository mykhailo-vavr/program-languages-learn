using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_I_Comparable_IClonable_etc_
{
    class MarkComparer : IComparer
    {
        public int Compare(object x, object y)
        {

            // (Student)x == x as Student

            Student student1 = (Student)x;
            Student student2 = (Student)y;

            if (student1 != null && student2 != null)
            {
                return student1.Average().CompareTo(student2.Average());
            }
            throw new ArgumentException("Error");
        }
    }
}
