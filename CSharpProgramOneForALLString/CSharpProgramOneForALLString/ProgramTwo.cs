using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProgramOneForALLString
{
    class ProgramTwo
    {
        public static void Run()
        {
            //Step 1: Create Sample Data
            List<Employee> employees = new List<Employee>()
            {
                new Employee  { Id = 1, Name="Alice", Department="HR", Salary= 60000 },
                new Employee  { Id = 2, Name="Bob", Department="IT", Salary= 80000 },
                new Employee  { Id = 3, Name="Charlie", Department="IT", Salary=95000 },
                new Employee  { Id = 4, Name="David", Department="Finance", Salary=70000 },
                new Employee  { Id = 5, Name="Eva", Department="HR", Salary=65000 }
            };

            //Step 2: LINQ Query Examples
            //1) Basic Query

            Console.WriteLine("===== List of All Employees =======");
            var allEmployees = from emp in employees
                               select emp;

            foreach (var e in allEmployees)
                Console.WriteLine($"\n Employee Id : {e.Id} \t Name : {e.Name} \t Department : ({e.Department}) - with salary as ${e.Salary}");

            //2) Filtering
            Console.WriteLine("\n");
            Console.WriteLine("===== List of Employees having Salary > 70000 ======");
            var highSalary = from emp in employees
                             where emp.Salary > 70000
                             select emp;

            foreach (var e in highSalary)
                Console.WriteLine($"\nEmployee Id : {e.Id} \t {e.Name} getting salary {e.Salary}");

            //3) Lambda Syntax
            Console.WriteLine("\n====== List of Employees from IT Department ========");
            var ItEmployee = employees.Where(x => x.Department == "IT");

            foreach (var e in ItEmployee)
                Console.WriteLine($"\n Employee Id : {e.Id} \t {e.Name} ({e.Department})");

            //4) Grouping And Aggregation
            Console.WriteLine("\n======= Average Salary Per Department=======");
            var avrSalaryperDept = from emp in employees
                                   group emp by emp.Department into DeptGroup
                                   select new
                                   {
                                       Department = DeptGroup.Key,
                                       AverageSalary = DeptGroup.Average(x => x.Salary)
                                   };

            foreach (var e in avrSalaryperDept)
                Console.WriteLine($"\n {e.Department} : ${e.AverageSalary:F2}");

            //5) Sorting
            Console.WriteLine("\n=========Sorted by Salary Descending ==========");
            var sortedbySalary = employees.OrderByDescending(emp => emp.Salary);

            foreach (var e in sortedbySalary)
                Console.WriteLine($"\n{e.Name} - {e.Salary}");

            //6 First Employee
            Console.WriteLine("\n=======First Employee=======");
            var firstIt = employees.FirstOrDefault(emp => emp.Department == "IT");
            Console.WriteLine(firstIt != null ? firstIt.Name : "No IT Employee found");

        }

        //Step 3: Define Employee Class
        class Employee
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Department { get; set; }
            public double Salary { get; set; }
        }
    }
}
