using System;
using System.Collections.Generic;

namespace HelloWorld{
  
  public class Counter{
    
    
    
    public void freqCounter(List<int> nums){
      
      Dictionary<int,int> freq = new Dictionary<int,int>();
      foreach(var item in nums){
        if(freq.ContainsKey(item)){
          freq[item]+= 1;
        }
        else{
          freq[item] = 1;
        }
      }
      
      foreach(var item in freq){
        Console.WriteLine($"{item.Key} -> {item.Value}");
      }
  
    }
  }
  
  public class Program{
    
    public static void Main(string[] args){
    
      string input =  Console.ReadLine();
      input = input.Replace("[","");
      input = input.Replace("]","");

    //   System.Console.WriteLine(input);
    
      string[] nums = input.Split(',');      
      List<int> para = new List<int>();
      
      for(int i = 0 ; i < nums.Length; i++){
        para.Add(int.Parse(nums[i].Trim()));
      }
      
      // string res1 = string.Join(" ", para);
      
      Counter count = new Counter();
      count.freqCounter(para);
    }
  }
}