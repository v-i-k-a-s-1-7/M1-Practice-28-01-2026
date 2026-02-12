using System;

public class LargestNumber
{
    public static void Main(string[] args)
    {
        // Find the Largest number in an Integer array
        int[] arr = {290,-89,-432,-675,-18,-98,-231};
        
        int max = arr[0];
        
        for(int i = 0 ; i < arr.Length; i++){
            if(max < arr[i]){
                max = arr[i];
            }
        }
        
        Console.WriteLine(max);
    }
}