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
            new Employee { Name = "Pooja", Department = "HR", Salary = 45000 },
            new Employee { Name = "Karan", Department = "Finance", Salary = 55000 }
        };

        // TODO: Group by Department and calculate total salary
        var groupByDept = employees.GroupBy(e=> e.Department)
                                    .Select(g=> new{
                                       Department = g.Key,
                                       TotalSalary = g.Sum(s=> s.Salary)
                                    });
        
        foreach(var item in groupByDept){
          
          Console.WriteLine($"{item.Department} -> {item.TotalSalary}");
        }
    }
}
