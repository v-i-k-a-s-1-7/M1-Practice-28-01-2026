using System;
using System.Collections.Generic;
using System.Linq;


public class BankRiskException : Exception{
  
  public BankRiskException(string message) : base(message){
    
  }
}
public class Program{
  
  public static void Main(string[] args){
    
    BankRiskValidation bank = new BankRiskValidation();
    string input = Console.ReadLine();
    string input1 = Console.ReadLine();
    int.TryParse(input ,out int age);
    int.TryParse(input1, out int creditScore);

    try
    {
        bank.isEligible(age,creditScore);
    }
    catch(BankRiskException ex)
    {
        System.Console.WriteLine(ex.Message);
    }
      
  }
}

public class BankRiskValidation{
  
    public void isEligible(int age, int creditScore){
        
        if(age < 21)
          throw new BankRiskException("Invalid Age");
        if(creditScore < 300  || creditScore > 850)
          throw new BankRiskException("Invalid creditScore");
          
        Console.WriteLine("Customer Eligible");
    }
}