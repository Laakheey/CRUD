using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment
{
    class EmployeeById
    {
        public EmployeeById(List<Employee> employeeList)
        {
            Employee_Id_Lable:
            Console.WriteLine("Enter the employee Id to search for: ");
            string employeeId = Console.ReadLine();

            var employees = employeeList.Where(emp => emp.Id.ToLower() == employeeId.ToLower());

            
            if (employees.Any())
            {
                Console.WriteLine("Employees with employee Id {0} :", employeeId);
                Console.WriteLine();
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Id:\tName:\tDepartment:\tCompany_Name\tTechnology");

                foreach (var emp in employees)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}", emp.Id, emp.Name, emp.Department, emp.Company_Name, emp.Technology);
                }
                Console.WriteLine("****************************************************************************");

            }
            else
            {
                Console.WriteLine("No employees with Id {0} ", employeeId);
                goto Employee_Id_Lable;
            }
        }
    }
}
