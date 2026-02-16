using System;
using System.Collections.Generic;


class Salary{
    
    Dictionary<string,int> empList = new Dictionary<string,int>();
    
    public int totalSalary(){
        
        int totalSalary = 0;
        foreach(var item in empList){
            totalSalary += item.Value;
        }
        
        return totalSalary;
    }
    
    public string getSalary(string designation){
        
        foreach(var item in empList){
            if(designation == item.Key){
                return $"Salary is {item.Value}";
            }
        }
        return "No Designation Match";
    }
    
    public void updateSalary(string designation, int newSalary){
        
        foreach(var item in empList){
            if(designation == item.Key){
                empList[item.Key] = newSalary;
                break;
            }
        }
    }
    
    public void addEmployee(string designation, int salary)
    {
        empList[designation] = salary;
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        Salary salary = new Salary();

        // adding employees
        salary.addEmployee("Developer", 50000);
        salary.addEmployee("Tester", 40000);
        salary.addEmployee("Manager", 80000);

        // total salary
        Console.WriteLine("Total Salary: " + salary.totalSalary());

        // get salary by designation
        Console.WriteLine(salary.getSalary("Developer"));
        Console.WriteLine(salary.getSalary("HR"));

        // update salary
        salary.updateSalary("Tester", 45000);

        // verify update
        Console.WriteLine(salary.getSalary("Tester"));
    }
}
