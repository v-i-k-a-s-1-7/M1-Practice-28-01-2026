using System;

namespace HelloWorld{
  
  public class StringEncoder{
    
    public string validator(string input){
      
      int n = input.Length;
      string res = "";
      
      if(n <= 5){
        return "Invalid Input";
      }
      
      foreach(var item in input){
        
        if(Char.IsDigit(item)){
          return "Invalid Input";
        }
        
        if(Char.IsWhiteSpace(item)){
          return "Invalid Input";
        }
        
        int num = (int)item + n;
        res+= (char)num;
      }
      
      return res;
      
    }
    
    public static void Main(string[] args){
      
      StringEncoder sEncode = new StringEncoder();
      string input = Console.ReadLine();
      
      string ans = sEncode.validator(input);
      
      Console.WriteLine(ans);
    }
    
  }
}
