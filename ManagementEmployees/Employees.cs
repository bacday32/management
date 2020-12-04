using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementEmployees
{
    class Employees
    {
        public string idEmployees { get; set; }
        public string fullName { get; set; }
        public string dateOfBirth { get; set; }
        public string address { get; set; }
        public string position { get; set; }
        public int salary { get; set; }
        public Employees(string idEmployees, string fullName, string dateOfBirth, string position, int salary)
        {
            this.idEmployees = idEmployees;
            this.fullName = fullName;
            this.dateOfBirth = dateOfBirth;
            this.address = address;
            this.position = position;
            this.salary = salary;
        }

        public Employees()
        {
        }

        public void Add()
        {
            Console.WriteLine("Enter new id for Employee!!!");
            this.idEmployees = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter full name employees :");
            this.fullName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter date of birthday employees :");
            this.dateOfBirth = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter position employees :");
            this.address = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter address employees :");
            this.position = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter salary employees :");
            this.salary = int.Parse(Console.ReadLine());
        }
        public void Remove(string idEmployees)
        {

        }
        public void Show()
        {
            
        }


    }
}
