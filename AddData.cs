using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment
{
    class AddData
    {
        public AddData(List<Employee> employeeList)
        {
            Validation valid = new Validation();

            Console.WriteLine("Enter employee Id");
            string Id = valid.CheckId(Console.ReadLine());

            Console.WriteLine("Enter employee name: ");
            string Name = valid.CheckName(Console.ReadLine());

            Console.WriteLine("Enter employee department name: ");
            string deptName = valid.CheckName(Console.ReadLine());

            Console.WriteLine("Enter employee company name: ");
            string compName = valid.CheckName(Console.ReadLine());

            Console.WriteLine("Enter employee technology used: ");
            string tech = valid.CheckName(Console.ReadLine());

            Employee emp = new Employee();
            emp.Id = Id;
            emp.Name = Name;
            emp.Department = deptName;
            emp.Company_Name = compName;
            emp.Technology = tech;
            employeeList.Add(emp);

        }
    }
}
