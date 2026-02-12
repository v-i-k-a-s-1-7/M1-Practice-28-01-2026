using System;
using System.Collections.Generic;

public class FindSum
{
    public static void Main(string[] args)
    {
        // Find the sum of all elements in an array.
       int[] arr = {10,20,32,65,30,21,45};
       int sum = 0;
       for(int i = 0 ; i< arr.Length ; i++){
           sum+= arr[i];
       }
        
        Console.WriteLine(sum);
    }
}