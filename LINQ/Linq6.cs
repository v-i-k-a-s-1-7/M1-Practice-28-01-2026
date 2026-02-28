using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
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
            new Employee { Name = "A", Department = "IT", Salary = 50000 },
            new Employee { Name = "B", Department = "IT", Salary = 60000 },
            new Employee { Name = "C", Department = "HR", Salary = 40000 }
        };

        // TODO:
        // Group by Department
        var groupByDept = employees
                          .GroupBy(g=> g.Department)
                          .Select(g=> new {
                              Department= g.Key,
                              TotalSalary = g.Sum(s=> s.Salary)
                          });
        
        foreach(var item in groupByDept){
          Console.WriteLine($"Dept: {item.Department} -> {item.TotalSalary}");
        }
        
        // Calculate total salary per department
        // Print output
    }
}
