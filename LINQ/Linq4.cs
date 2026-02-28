using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> salaries = new List<int>
        {
            30000, 40000, 50000
        };

        // TODO:
        // Calculate total salary
        
        int totalSalary = salaries.Sum(s=> s);
        // Calculate average salary
        double averageSalary = salaries.Average(s=> s);
        // Print both
        
        Console.WriteLine($"Total: {totalSalary} \nAverage: {averageSalary}");
    }
}
