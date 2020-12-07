using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ManagementEmployees;
using System.Collections;

namespace ManagementEmployees
{
    class Program
    {
        static void Main(string[] args)
        {

            //create list contain object employess
            List<Employees> list = new List<Employees>();
            // read file csv
            string file = @"C:\Users\Admin\Documents\management\InforEmployee.csv";

            var filePath = File.ReadAllLines(file);
            int count = 0;
            //loop file , get value add in list

            foreach (var line in filePath)
            {
                if (count == 0)
                {
                    count++;
                    continue;
                }
                var value = line.Split(',');
                Employees employees = new Employees { idEmployees = value[0], fullName = value[1], dateOfBirth = value[2], address = value[3], position = value[4], salary = int.Parse(value[5]) };
                list.Add(employees);
            }
            Options();
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                //add new employ in file
                case 1:
                    try
                    {
                        Employees newEmployee = new Employees();
                        newEmployee.AddEmployee();
                        var idnew = newEmployee.idEmployees;
                        Employees employRemove = list.First(s => s.idEmployees == idnew);
                        File.AppendAllText(file, "\n" + newEmployee.ToString());
                        Console.WriteLine("You have added 1 new employee!!!! ");
                        Console.ReadLine();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("id employess existed!!!" + ex);
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Enter id Employees you want remove:");
                        string idRemove = Console.ReadLine();
                        // Employees employ = new Employees();  
                        Employees employRemove = list.First(s => s.idEmployees == idRemove);
                        list.Remove(employRemove);
                        //string[] arrEmployee = list.ToArray();
                        List<string> strings = list.Select(s => s.ToString()).ToList();
                        foreach (Employees item in list)
                        {
                            File.WriteAllLines(file, strings);
                        }
                        Console.ReadLine();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("id Employees not exist!!!" + ex);
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    try
                    {
                        Console.WriteLine("Enter id employee you want repair: ");
                        string idRepair = Console.ReadLine();
                        Employees employee = list.First(s => s.idEmployees == idRepair);
                        int index = list.IndexOf(employee);
                        Employees employeeRepair = InputRepair(employee, idRepair);
                        list.Insert(index, employeeRepair);

                        list.Remove(employee);
                        List<string> strings = list.Select(s => s.ToString()).ToList();
                        foreach (Employees item in list)
                        {
                            File.WriteAllLines(file, strings);
                        }
                        Console.WriteLine("SUCCESSFUL!!!");
                        Console.WriteLine(employeeRepair);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("id Employees not exist!!!" + ex);
                        Console.ReadLine();
                    }
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("1:find employees by id?");
                    Console.WriteLine("2:find employees by name?");
                    int find = int.Parse(Console.ReadLine());
                    switch (find)
                    {
                        case 1:
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Enter id employee you want find: ");
                                    string idFind = Console.ReadLine();
                                    Employees employee = list.First(s => s.idEmployees == idFind);
                                    Console.WriteLine(employee);
                                    Console.ReadLine();
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Not found!!!", ex);
                                    Console.ReadLine();
                                }
                            }
                            while (true);
                            break;
                        case 2:

                            do
                            {
                                try
                                {
                                    Console.WriteLine("Enter name employee you want find: ");
                                    string nameFind = Console.ReadLine();
                                    Employees employee = list.First(s => s.fullName == nameFind);
                                    Console.WriteLine(employee);
                                    Console.ReadLine();
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Not found!!!", ex);
                                    Console.ReadLine();
                                }
                            }
                            while (true);
                            break;
                    }
                    break;

                case 5:
                    //show list employee
                    DisplayEmployee(list);
                    Console.ReadLine();
                    break;
                case 6:
                    while(true)
                    {
                        Console.WriteLine("Choose a number: ");
                        Console.WriteLine("1-----Previous-----");
                        Console.WriteLine("2-----Next-----");
                        Console.WriteLine("3-----Fisrt-----");
                        Console.WriteLine("4-----Last-----");
                        int num = int.Parse(Console.ReadLine());

                        int indexDetail = 5;
                        Console.WriteLine(list[indexDetail]);
                        switch (num)
                        {

                            case 1:
                                if (indexDetail - 1 > -1)
                                {
                                    var prev = list[indexDetail - 1];
                                    Console.WriteLine(list[indexDetail - 1]);
                                    indexDetail--;
                                }
                                Console.ReadLine();
                                break;
                            case 2:
                                if (indexDetail + 1 < list.Count)
                                {
                                    var next = list[indexDetail + 1];
                                    Console.WriteLine(list[indexDetail + 1]);
                                    indexDetail++;
                                }
                                Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine(list.First());
                                Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine(list.Last());
                                Console.ReadLine();
                                break;
                            default:
                                break;
                        }
                    }
                    
                    break;
                case 7:
                    break;
                default:

                    break;
            }
        }

        static void DisplayEmployee(List<Employees> list)
        {
            foreach (Employees employee in list)
            {
                employee.Display();
            }
        }
        static void Options()
        {
            Console.WriteLine("Choose a number:");
            Console.WriteLine("1:-----Add Employees-----");
            Console.WriteLine("2:-----Remove Employees-----");
            Console.WriteLine("3:-----Repair information Employee-----");
            Console.WriteLine("4:-----Find Employees-----");
            Console.WriteLine("5:-----Show list Employees-----");
            Console.WriteLine("6:-----Detail employee-----");
            Console.WriteLine("7:-----Exit-----");

        }
        static Employees InputRepair(Employees employee, string idRepair)
        {
            Employees employeeRepair = new Employees();
            Console.WriteLine(employee);
            employeeRepair.idEmployees = idRepair;
            Console.WriteLine("Enter full name employees :");
            employeeRepair.fullName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter date of birthday employees :");
            employeeRepair.dateOfBirth = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter position employees :");
            employeeRepair.address = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter address employees :");
            employeeRepair.position = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter salary employees :");
            employeeRepair.salary = int.Parse(Console.ReadLine());
            return employeeRepair;
        }
    }
}
