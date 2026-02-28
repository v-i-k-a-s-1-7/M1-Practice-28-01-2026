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
            new Employee { Name = "C", Department = "IT" }
        };

        // TODO:
        // Use LINQ Select
        // Store only names in a new list
        List<string> newList = new List<string>();
        
        newList = employees.Select(e=> e.Name).ToList();
        
        string res = string.Join("\n",newList);
        // Print the names
        Console.WriteLine(res);
    }
}
