using System;
using System.Collections.Generic;



class Program
{
   
    public static void Main(string[] args){
      string input = Console.ReadLine();
      
      if(!int.TryParse(input, out int num)){
        Console.WriteLine("Invalid Input");
        return;
      }
      
      if(num % 2 == 0){
        num+=1;
      }
      
      Console.WriteLine(num);
    }
}
