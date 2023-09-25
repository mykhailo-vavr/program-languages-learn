using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    class Employee
    {
        private string name;
        private DateTime hiringDate;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public DateTime HiringDate
        {
            get => hiringDate;
            set => hiringDate = value;
        }

        public Employee() {}

        public Employee(string name, DateTime hiringDate)
        {
            this.name = name;
            this.hiringDate = hiringDate;
        }
        public int Experience()
        {
            DateTime now = DateTime.Now;
            return now.Year - hiringDate.Year;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"{name}, experience: {Experience()}");
        }

        public virtual string ToString()
        {
            return $"{name}, hired in: {Experience()}";
        }
    }
}
