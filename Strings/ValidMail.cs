// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class ValdiMail{
    
    public bool ValidEmail(string email){
        
        if(string.IsNullOrEmpty(email))
            return false;
        
        if(email.Contains(' '))
            return false;
        
        if(!email.Contains('@'))
            return false;
        
        // Must contain one '@'
        if(email.Count(c=> c == '@') != 1)
            return false;
        
        
        string[] parts = email.Split('@');
        if(parts.Length != 2)
            return false;
            
        string name = parts[0];
        string domain = parts[1];
        
        if( string.IsNullOrEmpty(name) || 
            string.IsNullOrEmpty(domain))
            return false;
        
        if(! domain.Contains('.'))
            return false;
        
        if(domain.Count(c => c == '.') != 1)
            return false;
        
        if(domain[domain.Length - 1] == '.')
            return false;
        
        
        return true;
    }
}
public class HelloWorld
{
    public static void Main(string[] args)
    {
       ValidMail isValid = new ValidMail();
       
       string email = Console.ReadLine();
       isValid.ValidMail(email);
       
    }
}