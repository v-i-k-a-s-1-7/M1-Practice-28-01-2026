using System;
using System.Collections.Immutable;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace Generics
{
    public delegate void Callback(string message);
    public class Student
    {
        public int StudentId{get;set;}
        public string Name{get;set;}
        public List<int> Marks{get;set;}
        public double AverageMarks => Marks.Average();

        public Student(int studentId , string name, List<int> marks)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Marks = marks;
            // this.AverageMarks = average;
        }




    }

    
}