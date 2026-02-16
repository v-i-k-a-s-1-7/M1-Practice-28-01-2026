using System;
using System.Collections.Generic;

public class Attendance{
    
    public HashSet<int> firstUnique(List<int> scans){
        
        HashSet<int> attendance = new HashSet<int>();
        foreach(var item in scans){
            
            attendance.Add(item);
        }
        
        return attendance;
    }
    
    public static void Main(string[] args){
        
        List<int> att = new List<int>{
            
            10,20,10,30,20,40
        };
        Attendance attendance =  new Attendance();
        HashSet<int> res = attendance.firstUnique(att);
        
        Console.WriteLine("[" + string.Join(", " , res)+ "]");
        
    }
}