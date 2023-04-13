using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment
{
    class UpdateRow
    {
        public UpdateRow(List<Employee> employeeList)
        {
            Validation valid = new Validation();
            bool found = false;
            while (!found)
            {
                Console.WriteLine("Enter the id you want to update");
                string updateId = Console.ReadLine();

                foreach (Employee emp in employeeList)
                {
                    if (emp.Id == updateId)
                    {
                        Console.WriteLine("Enter new name");
                        emp.Name = valid.CheckName(Console.ReadLine());
                        Console.WriteLine("Enter new department");
                        emp.Department = valid.CheckDepartment(Console.ReadLine());
                        Console.WriteLine("Enter new company name");
                        emp.Company_Name = valid.CheckCompanyName(Console.ReadLine());
                        Console.WriteLine("Enter new technology");
                        emp.Technology = valid.CheckTechnology(Console.ReadLine());

                        Console.WriteLine();
                        Console.WriteLine("Data Updated Successfully");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Invalid ID. Please try again.");
                }
            }
        }
    }
}
