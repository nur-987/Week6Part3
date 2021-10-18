using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Sam",
                Address = "xxx",
                Salary = 3000

            };
            Employee emp2 = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = "Kat",
                Address = "bbb",
                Salary = 5000

            };
            List<Employee> empList = new List<Employee>();
            empList.Add(emp);
            empList.Add(emp2);

            Console.WriteLine("serialize");
            string employeeJson = JsonConvert.SerializeObject(emp);
            File.WriteAllText("Employee.json", employeeJson);

            //serializing list
            string employeeListJson = JsonConvert.SerializeObject(empList);
            File.WriteAllText("EmployeeList.json", employeeListJson);

            Console.ReadLine();

            //to read json text
            Console.WriteLine("deserialize");
            Employee empTemp = JsonConvert.DeserializeObject<Employee>(File.ReadAllText("Employee.json"));

            //deserealize a list
            List<Employee> empListTemp = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText("EmployeeList.json"));

            //store this file that was read into another file
            string employeeJson1 = JsonConvert.SerializeObject(empTemp);
            File.WriteAllText("Employee2.json", employeeJson1);

            //for List 
            string employeeListJson1 = JsonConvert.SerializeObject(empListTemp);
            File.WriteAllText("Employee2List.json", employeeListJson1);

            Console.ReadLine();

        }
    }
}
