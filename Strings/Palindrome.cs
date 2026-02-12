using System;
using System.Collections.Generic;

public class CheckPalindrome
{
    public static void Main(string[] args)
    {
        // Check if a given string is a palindrome.
        string name = "racecar";
        bool palindrome = true;
        for(int i = 0; i <= (int)name.Length/2; i++){
            if(name[i] != name[name.Length - i - 1])
                palindrome = false;
        }
        
        Console.WriteLine(palindrome ? "Palindrome" : "Not Palindrome");
        
    }
}