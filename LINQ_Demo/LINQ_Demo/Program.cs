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

            List<Department> lstDeparment = new List<Department>();
            Department dept = new Department() { DepartmentName = "IT", DepartmentID = 1 };
            lstDeparment.Add(dept);
            dept = new Department() { DepartmentName = "HR", DepartmentID = 2 };
            lstDeparment.Add(dept);


            List<Employee> lstEmployee = new List<Employee>();
            Employee emp = new Employee() { EmployeeName = "Scott", DepartmentID = 1 };
            lstEmployee.Add(emp);
            emp = new Employee() { EmployeeName = "Allen", DepartmentID = 1 };
            lstEmployee.Add(emp);
            emp = new Employee() { EmployeeName = "David", DepartmentID = 2 };
            lstEmployee.Add(emp);

            // get employees and their respective department name 
            var query = from deparment in lstDeparment
                        join employee in lstEmployee
                        on deparment.DepartmentID equals employee.DepartmentID
                        select new { employee.EmployeeName, deparment.DepartmentName };
            foreach (var item in query)
            {
                Console.WriteLine($"{item.EmployeeName}: {item.DepartmentName}");
            }

            Console.ReadLine();

            var query1 = from employee in lstEmployee
                         join department in lstDeparment
                         on
                         employee.DepartmentID equals department.DepartmentID
                         group department by department.DepartmentName;


            foreach (var item in query1)
            {
                Console.WriteLine($"{item.Key}:{item.Count()}");
            }

            Console.ReadLine();

            var query2 = lstDeparment.GroupJoin(lstEmployee, d => d.DepartmentID, e => e.DepartmentID, 
                (department, employee) => 
                new {
                    Dept =department ,
                    Emp = employee
                });



            foreach (var results in query2)
            {
                Console.WriteLine(results.Dept.DepartmentName);
                Console.WriteLine("**********************************");
                foreach (var employee in results.Emp)
                {
                    Console.WriteLine(employee.EmployeeName);

                }
            }

            Console.ReadLine();

            int[] numbers = new int[] { 1, 2, 3, 4 };
            var result = numbers.Aggregate((a, b) => a + b);
            Console.WriteLine(result);

            Console.ReadLine();


        }

        class Employee
        {
            public int DepartmentID { get; set; }
            public string EmployeeName { get; set; }
        }

        class Department
        {
            public int DepartmentID { get; set; }
            public string DepartmentName { get; set; }
        }

    }
}
