using System;
using System.Text.RegularExpressions;

namespace HelloWorld{
  
  public class ProductCodeValidator{
    
    public string Validator(string input){
      
      string[] splits = input.Split('|');
      
      if(splits.Length != 4)
        return "INVALID PRODUCT";
        
      string productId = splits[0];
      string category = splits[1];
      string price = splits[2];
      string status = splits[3];
      
      string productPattern = "^PRD-[1-9][0-9]{3}$";
      string categoryPattern = "^(ELEC|FOOD|CLOTH|MED)$";
      string pricePattern = @"^(0|[1-9][0-9]{0,3})(\.[0-9]{1,2})?$";
      string statusPattern = "^(AVAILABLE|OUTOFSTOCK|DISCONTINUED)$";
      
      if(!Regex.IsMatch(productId,productPattern)){
        return "INVALID PRODUCT";
      }
      if(!Regex.IsMatch(category,categoryPattern))
        return "INVALID PRODUCT";
      if(!Regex.IsMatch(price,pricePattern))
        return "INVALID PRODUCT";
      if(!Regex.IsMatch(status,statusPattern))
        return "INVALID PRODUCT";
      
      return "VALID PRODUCT";
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