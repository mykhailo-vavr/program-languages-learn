using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_I_Comparable_IClonable_etc_
{
    class Student : IComparable, ICloneable
    {
        private int[] marks = new int[5];

        public string Surname { get; set; }
        public string Name { get; set; }
        public Student() { }
        public Student(string surname, string name)
        {
            Surname = surname;
            Name = name;
        }
        public int this[int index]
        {
            get => marks[index];
            set => marks[index] = value;
        }
        public override string ToString()
        {
            string result = $"{Name} {Surname} ";
            foreach (int mark in marks)
            {
                result += mark + ", ";
            }
            return result;
        }

        public int CompareTo(object obj)
        {
            Student other = obj as Student;
            if(other == null)
            {
                throw new ArgumentException("Error in object converting to Student");
            }
            
            if (this.Surname.CompareTo(other.Surname) != 0)
                return this.Surname.CompareTo(other.Surname);

            return this.Name.CompareTo(other.Name);
                
        }

        public object Clone()
        {
            Student student_clone = new Student(Surname, Name);

            for (int i = 0; i < marks.Length; i++)
            {
                student_clone[i] = marks[i];
            }

            return student_clone;
        }
        public double Average()
        {
            double sum = 0;
            foreach (var mark in marks)
            {
                sum += mark;
            }

            int count = 1;
            if (marks.Length != 0) count = marks.Length;

            return sum / count;
        }
    }

}
