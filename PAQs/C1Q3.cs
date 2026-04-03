using System;
using System.Text.RegularExpressions;

namespace HelloWorld{
  
  public class ProductCodeValidator{
    
    public string Validator(string input){
      
      string pattern = @"^[a-z]{3,}\.[a-z]{3,}[0-9]{3,}@(hr|it|finance|admin)\.company\.com$";
      
      if(Regex.IsMatch(input,pattern))
        return "VALID";
      
      return "INVALID";
    }
    
   
  }
  
  public class Program{
     public static void Main(string[] args){
      
      ProductCodeValidator prod = new ProductCodeValidator();
      string input = "";
      string res = "";
      int n = int.Parse(Console.ReadLine());
      for(int i = 0; i< n; i++){
        
         input = Console.ReadLine();
         res = prod.Validator(input);
         Console.WriteLine(res);
      }
      
      
    }
  }
}