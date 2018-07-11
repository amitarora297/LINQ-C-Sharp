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

            var lstFilteredEmployee =  lstEmployee.Where(delegate(Employee argEmp)
            {
                return argEmp.Name.StartsWith("S");
            });

            foreach (var item in lstFilteredEmployee)
            {
                Console.WriteLine(item.Name);
            }
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
