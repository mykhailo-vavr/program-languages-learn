using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    class Developer: Employee
    {
        private string programmingLanguage;

        public string ProgrammingLanguage 
        {
            get => programmingLanguage; 
            set => programmingLanguage = value; 
        }

        public Developer(): base() {}

        public Developer(string name, DateTime hiringDate, string programmingLanguage): base(name, hiringDate)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"{Name} is {programmingLanguage} programmer");
        }

        public override string ToString()
        {
            return base.ToString() + $" ,language: {programmingLanguage}";
        }
    }
}
