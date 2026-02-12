using System;

public class RevrseString
{
    public static void Main(string[] args)
    {
        string name = "Hello";
        string rev = "";
        
        for(int i = name.Length-1; i>= 0 ; i--){
            rev += name[i];
        }
        
        Console.WriteLine(rev);
    }
}