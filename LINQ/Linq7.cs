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
            new Employee { Name = "B", Department = "IT" },
            new Employee { Name = "C", Department = "HR" },
            new Employee { Name = "D", Department = "HR" },
            new Employee { Name = "E", Department = "HR" }
        };

        // TODO:
        // Group by Department
        // Print: IT -> 2, HR -> 3
        var countDeptEmp = employees.GroupBy(e=> e.Department)
                                    .Select(e=> new
                                    {
                                        Department = e.Key,
                                        TotalEmployee = e.Count()
                                    });
        
        foreach(var group in countDeptEmp)
        {
            System.Console.WriteLine($"{group.Department} -> {group.TotalEmployee}");
        }
    }
}
