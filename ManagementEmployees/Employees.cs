using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementEmployees
{
    class Employees
    {
        public int idEmployees { get; set; }
        public string fullName { get; set; }
        public string dateOfBirth { get; set; }
        public string address { get; set; }
        public string position { get; set; }
        public int salary { get; set; }
        public Employees(int idEmployees, string fullName, string dateOfBirth, string position, int salary)
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
        public void AddNewEmployee()
        {
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
        public void Display()
        {
            Console.WriteLine("id employees : {0},full name :{1}, date of birthday: {2},address: {3},postion: {4} , salary: {5}", idEmployees, fullName, dateOfBirth, address, position, salary);
        }
        public override string ToString()
        {
            return this.idEmployees + "," + this.fullName + "," + this.dateOfBirth + "," + this.address + "," + this.position + "," + this.salary;
        }
    }



}
