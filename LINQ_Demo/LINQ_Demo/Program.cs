using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> lstEmployee = new List<Employee>();
            Employee emp = new Employee() { Name = "Scott" };
            lstEmployee.Add(emp);
            emp = new Employee() { Name = "Allen" };
            lstEmployee.Add(emp);
            emp = new Employee() { Name = "David" };
            lstEmployee.Add(emp);

            var lstFilteredEmployee =  lstEmployee.Where(e=> e.Name.StartsWith("S"));

            foreach (var item in lstFilteredEmployee)
            {
                Console.WriteLine(item.Name);
            }
            

            Func<int, int> square = x => x * x;
            Func<int, int, int> area = (x, y) => x * y;
            Action<int> print = x => Console.WriteLine(x); 

            Console.WriteLine(square(7));
            print(area(3,2));
            Console.ReadLine();

        }

        private static bool startWithS(Employee emp)
        {
            return emp.Name.StartsWith("S");
        }
    }

    class Employee
    {
        public string  Name { get; set; }
    }

}
