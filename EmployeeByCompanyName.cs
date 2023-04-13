using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment
{
    class EmployeeByCompanyName
    {
        public EmployeeByCompanyName(List<Employee> employeeList)
        {
            Company_Name_Label:
            Console.WriteLine("Enter the company name to search for: ");
            string companyName = Console.ReadLine();

            var employees = employeeList.Where(emp => emp.Company_Name.ToLower() == companyName.ToLower());

            if (employees.Any())
            {
                Console.WriteLine("Employees working for {0} company:", companyName);
                Console.WriteLine("Id:\tName:\tDepartment:\tCompany_Name\tTechnology");

                Console.WriteLine("*****************************************************");
                foreach (var emp in employees)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}", emp.Id, emp.Name, emp.Department, emp.Company_Name, emp.Technology);
                }
                Console.WriteLine("*****************************************************");

            }
            else
            {
                Console.WriteLine("No employees found working for {0} company", companyName);
                goto Company_Name_Label;
            }
        }
    }
}
