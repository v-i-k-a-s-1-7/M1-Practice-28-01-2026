using System;
using System.Collections.Generic;
using Mixed;

namespace Mixed
{
     public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name="A", Department="IT", Salary=50000 },
                new Employee { Name="B", Department="HR", Salary=40000 },
                new Employee { Name="C", Department="IT", Salary=60000 },
                new Employee { Name="D", Department="HR", Salary=45000 }
            };
            
            Salary salary = new Salary();
            // TODO:
            // 1. Total IT salary
            double totalItSalary = salary.TotalSalary(employees);
            System.Console.WriteLine($"Total Salary for IT Dept is {totalItSalary}");
            // 2. Average HR salary
            double HrAvgSalary = salary.HrAvgSalary(employees);
            System.Console.WriteLine($"Average Salary of HR dept is {HrAvgSalary}");
            // 3. Departments with more than 1 employee

            string deptNames = string.Join(",",salary.DepartmentWithMorePeople(employees));

            System.Console.WriteLine(deptNames);
            

        }
    }

    class Salary
    {
        public double TotalSalary(List<Employee> emp)
        {
            double totalSalary = 0;
            foreach(var item in emp)
            {
                if(item.Department == "IT")
                  totalSalary += item.Salary;
            }
            
            return totalSalary;
        }
        
        public double HrAvgSalary(List<Employee> emp){
          
          double hrTotalSalary = 0;
          double hrCount = 0;
          foreach(var item in emp){
            if(item.Department == "HR"){
              hrTotalSalary += item.Salary;
              hrCount += 1;
            }
          }
          
          return hrTotalSalary/hrCount;
          
        }
        
        public List<string> DepartmentWithMorePeople(List<Employee> emp){
          
          Dictionary<string,int> countEmp = new Dictionary<string,int>();
          List<string> departmentsWithMoreEmp = new List<string>();
          
          foreach(var item in emp){
            
            if(countEmp.ContainsKey(item.Department)){
              countEmp[item.Department] += 1;
            }
            else{
              countEmp[item.Department] = 1;
            }
          }
          
          foreach(var item in countEmp){
            if(item.Value > 1)
              departmentsWithMoreEmp.Add(item.Key);
          }
          
          return departmentsWithMoreEmp;
        }
    }

}