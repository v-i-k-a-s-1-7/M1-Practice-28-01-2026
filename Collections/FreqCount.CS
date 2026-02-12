using System;
using System.Collections.Generic;

public class CountFrequency
{
    public static void Main(string[] args)
    {
        // Find the frequency of elements in an array using a Dictionary
        int[] arr = {1,2,2,1,3,4,5,6,6,6,6,5,9};
        Dictionary<int,int> dict = new Dictionary<int,int>();
        
        foreach(var item in arr){
            
            if(dict.ContainsKey(item)){
                dict[item]++;
            }
            else{
                dict[item] = 1;
            }
        }
        
        
        Console.WriteLine(string.Join(',',dict));
    }
}