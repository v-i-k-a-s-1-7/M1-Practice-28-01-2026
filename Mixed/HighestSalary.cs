using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Amit", Department = "IT", Salary = 50000 },
            new Employee { Name = "Neha", Department = "HR", Salary = 40000 },
            new Employee { Name = "Rahul", Department = "IT", Salary = 60000 },
            new Employee { Name = "Pooja", Department = "HR", Salary = 45000 }
        };

        // TODO: Find highest paid employee WITHOUT sorting
        
        var maxSalary = employees.Max(p=> p.Salary);
        
        var highestPaid = employees.Where(p=> p.Salary == maxSalary).Take(1);
        
        foreach(var item in highestPaid){
          Console.WriteLine(item.Name);
        }
    }
}
