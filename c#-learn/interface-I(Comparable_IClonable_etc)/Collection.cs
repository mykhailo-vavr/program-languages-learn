using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace interface_I_Comparable_IClonable_etc_
{
    class Collection : IEnumerable
    {
        private string group_name;
        private Student[] group = new Student[3];

        public string GroupName { get => group_name; set => group_name = value; }
        public int NumberGroup { get => group.Length; }
        public Collection() {}
        public Collection(string group_name)
        {
            this.group_name = group_name;
        }
        public void ReadFromFile(string filename)
        {
            string[] stringsOfStudents = File.ReadAllLines(filename);

            for (int i = 0; i < stringsOfStudents.Length; i++)
            {
                string[] studentValues = stringsOfStudents[i].Split(' ');

                group[i] = new Student
                {
                    Surname = studentValues[0],
                    Name = studentValues[1],
                };

                for (int j = 0; j < studentValues.Length - 2; j++)
                {
                    group[i][j] = Convert.ToInt32(studentValues[j + 2]);
                }
       
            }
        }
        public void SortByAlphabetic()
        {
            Array.Sort(group);
        }
        public void SortByAverage()
        {
            Array.Sort(group, new MarkComparer());
        }

        public IEnumerator GetEnumerator()
        {
            return group.GetEnumerator();
        }
    }
}
