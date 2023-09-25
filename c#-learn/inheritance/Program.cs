using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Avilio", new DateTime(2012, 08, 08));
            Developer developer = new Developer("Levi", new DateTime(2016, 07, 09), "C++");
            employee.ShowInfo();
            developer.ShowInfo();
        }
    }
}
