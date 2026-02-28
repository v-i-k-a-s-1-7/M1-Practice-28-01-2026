using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "A", Salary = 40000 },
            new Employee { Name = "B", Salary = 55000 },
            new Employee { Name = "C", Salary = 60000 }
        };

        // TODO:
        // Use FirstOrDefault
        var greaterThanfifty = employees.Where(e=> e.Salary > 50000)
                                        .Select(e=> e.Name)
                                        .FirstOrDefault();
        // Print employee name or "Not Found"
        // string res = new string(greaterThanfifty);
        if(!string.IsNullOrEmpty(greaterThanfifty)){
          Console.WriteLine(greaterThanfifty);
        }
        else{
          Console.WriteLine("Not Found");
        }
    }
}
