using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_Assignment
{
    class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Technology { get; set; }
        public string Company_Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>
            {
                new Employee
                {
                    Name = "Sunil",
                    Id = "1",
                    Department = "fsd",
                    Company_Name = "aspirefox",
                    Technology = "js"
                },
                new Employee
                {
                    Name = "Neeraj",
                    Id = "2",
                    Department = "jd",
                    Company_Name = "aspirefox",
                    Technology = "java"
                },
                new Employee 
                {
                    Name = "Neer",
                    Id = "2",
                    Department = "jd",
                    Company_Name = "aspire",
                    Technology = "java"
                }
                ,
                new Employee
                {
                    Name = "Nr",
                    Id = "2",
                    Department = "jd",
                    Company_Name = "asp",
                    Technology = "java"
                }
            };

            int exit = 0;
            while (exit!=1)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("1. Show");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Show Employee by company");
                Console.WriteLine("6. Show Employee by Id");
                Console.WriteLine("7. Exit");

                Console.WriteLine("----------------");

                Console.WriteLine("select what you want to do: ");
                string userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower();

                switch (userChoice)
                {
                    case "1": case "show":
                        Show();
                        break;
                    case "2": case "add":
                        Show();
                        new AddData(employeeList);
                        Show();
                        break;
                    case "3": 
                    case "update":
                        Show();
                        new UpdateRow(employeeList);
                        Show();
                        break;
                    case "4":
                    case "delete":
                        Show();
                        new DeleteRow(employeeList);
                        Show();
                        break;
                    case "5":
                    case "show employee by company name":
                        Show();
                        new EmployeeByCompanyName(employeeList);
                       // Show();
                        break;
                    case "6":
                    case "show employee by company id":
                        Show();
                        new EmployeeById(employeeList);
                        break;
                    case "7":
                    case "exit":
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Value! Enter valid value");
                        Console.WriteLine();
                        break;
                }
            }


            void Show()
            {
                Console.WriteLine();
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Id:\tName:\tDepartment:\tCompany_Name\tTechnology");
                foreach (Employee emp in employeeList)
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}",emp.Id , emp.Name , emp.Department , emp.Company_Name , emp.Technology);
                }
                Console.WriteLine("***************************************************************************");
                Console.WriteLine();
            }

            //Console.ReadLine();
        }
    }
}
