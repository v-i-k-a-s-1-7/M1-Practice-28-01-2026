using System;
using System.Collections.Generic;

public class RemoveDuplicates
{
    public static void Main(string[] args)
    {
        // Find the Largest number in an Integer array
        int[] arr = {290,200,230,290,290,280};
        
        HashSet<int> uniqueElements = new HashSet<int>();
        
        for(int i = 0 ; i < arr.Length; i++){
            
            uniqueElements.Add(arr[i]);
        }
        
        Console.WriteLine(string.Join(',',uniqueElements));
    }
}