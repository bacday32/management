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

            //var reader = new StreamReader(File.OpenRead(@"C:\InforEmployee.csv"));
            var list = new List<Employees>();
            var filePath = File.ReadAllLines(@"C:\Users\Desktop-win-bac\Documents\Visual Studio 2015\Projects\ManagementEmployees\InforEmployee.csv");
            int count = 0;
            foreach(var line in filePath)
            {   
                if(count == 0)
                {
                    count++;
                    continue;
                }

                var value = line.Split(','); 
                Employees employees = new Employees { idEmployees = value[0], fullName = value[1],  dateOfBirth= value[2], position= value[3], salary = int.Parse(value[4]) };
                list.Add(employees);
                Console.WriteLine(line);
            }

           
            Console.ReadLine();
            
            
        }
    }
}
