using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "A", Department = "IT" },
            new Employee { Name = "B", Department = "HR" },
            new Employee { Name = "C", Department = "IT" },
            new Employee { Name = "D", Department = "Finance" }
        };

        // TODO:
        // Count employees in IT department
        var count = employees.Count(e=> e.Department == "IT");
        // Print the count
        Console.WriteLine(count);
        
    }
}
