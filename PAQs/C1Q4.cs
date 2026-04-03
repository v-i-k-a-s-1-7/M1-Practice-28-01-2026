using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HelloWorld{
  
  public class StudentMarksRecords{
    
    public Dictionary<string,Dictionary<string,int>> StudentMarks = 
    new Dictionary<string,Dictionary<string,int>>();
    
    public void AddStudents(){
      
        string studentId = Console.ReadLine();
        string subjectName = Console.ReadLine();
        int marks = int.Parse(Console.ReadLine());
        
        if(! StudentMarks.ContainsKey(studentId)){
          StudentMarks[studentId] = new Dictionary<string,int>();
        }
        StudentMarks[studentId][subjectName] = marks;
    }
    
    public void PrintDict(){
      
      foreach (var student in StudentMarks){
        
        Console.WriteLine($"StudentId: {student.Key}");
        
        foreach(var s in student.Value){
          Console.WriteLine($"Subject: {s.Key} , Marks: {s.Value}");
        }
      }
    }
    
    
  }
  
  public class Program{
    
    public static void Main(string[] args){
      
      StudentMarksRecords s1 = new StudentMarksRecords();
      
      int n = int.Parse(Console.ReadLine());
      
      for(int i = 0; i< n; i++){
        s1.AddStudents();
      }
      
      s1.PrintDict();
      
    }
  }
}