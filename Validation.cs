using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_Assignment
{
    class Validation
    {
        public string CheckId(string id)
        {
            string idPattern = @"[0-9]$";
            while (!Regex.IsMatch(id, idPattern))
            {
                Console.WriteLine("Invalid Id! Enter employee Id Again");
                id = Console.ReadLine();
            }
            return id;
        }

        public string CheckName(string Name)
        {
            string namePattern = @"^[A-Za-z\s]+$";
            while (!Regex.IsMatch(Name, namePattern))
            {
                Console.WriteLine("Invalid Name! Enter employee's Name Again");
                Name = Console.ReadLine();
            }
            return Name;
        }


        public string CheckDepartment(string DeptName)
        {
            string deptPattern = @"^[A-Za-z\s]+$";
            while (!Regex.IsMatch(DeptName, deptPattern))
            {
                Console.WriteLine("Invalid Department Name! Enter employee's Department Name Again");
                DeptName = Console.ReadLine();
            }
            return DeptName;
        }

        public string CheckCompanyName(string companyName)
        {
            string compPattern = @"^[A-Za-z\s]+$";
            while (!Regex.IsMatch(companyName, compPattern))
            {
                Console.WriteLine("Invalid Company Name! Enter employee's Company Name Again");
                companyName = Console.ReadLine();
            }
            return companyName;
        }

        public string CheckTechnology(string Tech)
        {
            string techPattern = @"^[A-Za-z\s]+$";
            while (!Regex.IsMatch(Tech, techPattern))
            {
                Console.WriteLine("Invalid Technology Used! Enter Technology Used Again");
                Tech = Console.ReadLine();
            }
            return Tech;
        }
    }
}
