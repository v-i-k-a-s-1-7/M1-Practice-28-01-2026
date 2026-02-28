using System;
using System.Collections.Generic;
using System.Linq;

public class Program{
  
  public static void Main(string[] args){
    
    string input = Console.ReadLine();
    
    input = input.Replace("[","");
    input = input.Replace("]","");
    input = input.Trim();
    
    string[] list1 = input.Split(",");
    
    List<int> list = new List<int>();
    
    foreach(var item in list1){
      list.Add(int.Parse(item));
    }
    
    var ans = list.Where(e=> e > 20);
    
    string res = string.Join(",", ans);
    Console.WriteLine(res);
  }
}