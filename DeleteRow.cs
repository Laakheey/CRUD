using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment
{
    class DeleteRow
    {
        public DeleteRow(List<Employee> employeeList)
        {
            update_label:
            Console.WriteLine();
            Console.WriteLine("Enter the Id you want to delete: ");
            string del = Console.ReadLine();
            bool found = false;
            for (int i = employeeList.Count - 1; i >= 0; i--)
            {
                if (employeeList[i].Id == del)
                {
                    Console.WriteLine("Are you sure you want to delete? Yes/No");
                    string sure = Console.ReadLine();
                    sure = sure.ToLower();
                    if (sure == "yes")
                    {
                        employeeList.RemoveAt(i);
                        Console.WriteLine();
                        Console.WriteLine("Data Removed SuccessFully");
                    }
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter valid id");
                goto update_label;
            }
        }
    }
}
