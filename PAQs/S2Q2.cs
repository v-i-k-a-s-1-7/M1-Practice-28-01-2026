using System;
using System.Collections.Generic;

namespace HelloWorld{
  
  
  public class Member{
    public int TotalFine = 0;
    public int FinePaid = 0;
    public int OutstandingFine = 0;
    
  }
  
  public class FineManagement{
    
    public Dictionary<string,Member> memberMap = new Dictionary<string,Member>();
    
    public int AddMember(string memberId){
      
      if(! memberMap.ContainsKey(memberId)){
        memberMap[memberId] = new Member();
      }
      return 1;
    }
    
    public int ImposeFine(string memberId, int fine){
      if(! memberMap.ContainsKey(memberId)){
        return 0;
      }
      
      memberMap[memberId].TotalFine += fine;
      memberMap[memberId].OutstandingFine+= fine;
      
      return 1;
    }
    
    public int PayFine(string memberId, int fine){
       if(! memberMap.ContainsKey(memberId)){
        return 0;
      }
      memberMap[memberId].FinePaid += fine;
      memberMap[memberId].OutstandingFine-= fine;
      
      return 1;
    }
    
    public string GetDetails(string memberId){
      
      if(!memberMap.ContainsKey(memberId)){
        return "Member not Found";
      }
      var m = memberMap[memberId];
      return $"{memberId} {m.OutstandingFine} {m.TotalFine} {m.FinePaid}";
    }
    
    public int ProcessCommands(int n){
      
      for(int i = 0; i< n; i++){
        var input = Console.ReadLine().Split();
        
        if(input[0] == "ADD")
          AddMember(input[1]);
        
        if(input[0] == "IMPOSE")
          ImposeFine(input[1],int.Parse(input[2]));
        
        if(input[0] == "PAY")
          PayFine(input[1],int.Parse(input[2]));
        
        if(input[0] == "DETAILS"){
          Console.WriteLine(GetDetails(input[1]));
        }
      }
      return 1;
      
    }
  }
  
  public class Program{
    public static void Main(string[] args){
      
      int n = int.Parse(Console.ReadLine());
      
      FineManagement fine = new FineManagement();
      fine.ProcessCommands(n);
    }
  }
}