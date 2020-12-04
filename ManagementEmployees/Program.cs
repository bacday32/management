using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ManagementEmployees;


namespace ManagementEmployees
{
    class Program
    {
        static void Main(string[] args)
        {

            //create list contain object employess
            var list = new List<Employees>();
           // read file csv
            var filePath = File.ReadAllLines(@"C:\Users\Desktop-win-bac\Documents\Visual Studio 2015\Projects\ManagementEmployees\InforEmployee.csv");
            int count = 0;
            //loop file , get value add in list 
            foreach(var line in filePath)
            {   
                if(count == 0)
                {
                    count++;
                    continue;
                }
                var value = line.Split(',');
                
                Employees employees = new Employees { idEmployees = value[0], fullName = value[1],  dateOfBirth= value[2],address =value[3] ,position= value[4], salary = int.Parse(value[5]) };
                list.Add(employees);
                Console.WriteLine(line);
            }

            Console.WriteLine("Choose a number:");
            Console.WriteLine("1:-----Add Employees-----");
            Console.WriteLine("2:-----Remove Employees-----");
            Console.WriteLine("3:-----Repair information Employee-----");
            Console.WriteLine("4:-----Find Employees-----");
            Console.WriteLine("5:-----Show list Employees-----");
            int number = int.Parse(Console.ReadLine());
            switch(number)
            {
                case 1:


                    try
                    {   //create new list employee
                        var newList = new List<Employees>();
                        //create object employee
                        Employees newEmployee = new Employees();
                        
                        //get newid 
                        //string newId = Console.ReadLine();
                        //Console.WriteLine();
                        // 2
                        newEmployee.Add();
                        
                        newEmployee =list.First(s => s.idEmployees != newEmployee.idEmployees);

                        newList.Add(newEmployee);

                        foreach (var item in newList)
                        {
                            File.AppendAllText(@"C:\Users\Desktop-win-bac\Documents\Visual Studio 2015\Projects\ManagementEmployees\InforEmployee.csv", $"{item.idEmployees},{item.fullName},{item.dateOfBirth},{item.address},{item.position},{item.salary}\n",Encoding.Unicode);
                        }                        
                        break;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("id employess excisted!!!",ex);
                        Console.ReadKey();
                    }
                    break;


                case 2:
                    try
                    {
                        Console.WriteLine("Enter id Employees you want remove:");                        
                        string idRemove = Console.ReadLine();


                        
                        var employ = list.First(s => s.idEmployees == idRemove);
                        list.Remove(employ);
                        string[] arrEmployee = list.ToArray();

                        foreach (var item in list)
                        {
                            

                            File.WriteAllLines(@"C:\Users\Desktop-win-bac\Documents\Visual Studio 2015\Projects\ManagementEmployees\InforEmployee.csv", ($"{item.idEmployees},{item.fullName},{item.dateOfBirth},{item.address},{item.position},{item.salary}\n").ToArray());
                        }

                        break;

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("id Employees not exist!!!",ex);
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;

            }





        }
    }
}
