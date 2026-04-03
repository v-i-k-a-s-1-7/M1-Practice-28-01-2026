using System;
using System.Text.RegularExpressions;


namespace HelloWorld{

  public class Authenticator{
    
    public void IsValid(string input){
      
      string[] splits = input.Split("::");
      
      if(splits.Length != 2){
        Console.WriteLine("REJECTED DEVICE");
        return;
      }
      
      string ipAdd = splits[0];
      string macAdd = splits[1];
      
      string ipPattern = @"^[0-9a-fA-F]{1,4}:[0-9a-fA-F]{1,4}:[0-9a-fA-F]{1,4}:[0-9a-fA-F]{1,4}:[0-9a-fA-F]{1,4}:[0-9a-fA-F]{1,4}:[0-9a-fA-F]{1,4}:[0-9a-fA-F]{1,4}$";
      string macPattern = @"^[0-9A-F]{2}:[0-9A-F]{2}:[0-9A-F]{2}:[0-9A-F]{2}:[0-9A-F]{2}:[0-9A-F]{2}$";
    
      if(!Regex.IsMatch(ipAdd,ipPattern)){
        Console.WriteLine("REJECTED DEVICE");
        return;
      }
      
      if(!Regex.IsMatch(macAdd,macPattern)){
        Console.WriteLine("REJECTED DEVICE");
        return;
      }
      
      Console.WriteLine("AUTHENTIC DEVICE");
    }
  }
  
  public class Program{
    
    public static void Main(string[] args){
      
      Authenticator validity = new Authenticator();
      int n = int.Parse(Console.ReadLine());
      
      for(int i = 0; i< n ; i++){
        string input = Console.ReadLine();
        validity.IsValid(input);
      }
    }
  }
}