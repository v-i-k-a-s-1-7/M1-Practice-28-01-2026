using System;
using System.Net;
using System.Runtime.CompilerServices;
namespace ExceptionHandling
{
    public class InvalidEntryException : Exception
    {
        public InvalidEntryException(String message): base(message)
        {
            
        }
    }  

    public class EntryUtility
    {
        public bool validateEmployeeId(string employeeId)
        {
            int lengthOfString = employeeId.Length;

            if(lengthOfString != 10)
            {
                throw new InvalidEntryException("Invalid Entry");
            }
            
            string firstFiveChar= "";
            int count = 0;
            foreach(char item in  employeeId)
            {
                firstFiveChar += item;
                count++;
                if (count == 5)
                {
                    break;
                }
            }

            if(firstFiveChar != "GOAIR")
            {
                throw new InvalidEntryException("Invalid Entry");
            }

            string slashPresence = employeeId.Substring(5,1);

            if(slashPresence != "/")
            {
                throw new InvalidEntryException("Invalid Entry");
            }

            string IsNumber = employeeId.Substring(6,4);

            foreach(char item in IsNumber)
            {
                if (Char.IsDigit(item))
                {
                    continue;
                }
                else
                {
                    throw new InvalidEntryException("Invalid Entry");
                }
            }

            return true;
        }

        public bool validateDuration(int duration)
        {
            if(duration >=1 && duration <= 5)
            {
                return true;
            }
            else
            {
                throw new InvalidEntryException("Invalid Entry");
            }
        }
    }

    public class Program2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your Employee Id");
            string EmpId = Console.ReadLine();

            Console.WriteLine("Enter Your Entry Type");
            string EntryType = Console.ReadLine();

            Console.WriteLine("Enter Duration");
            int duration = int.Parse(Console.ReadLine());

            EntryUtility eu = new EntryUtility();

            try{
                bool validityId = eu.validateEmployeeId(EmpId);
                bool durationValidity = eu.validateDuration(duration);

                if (validityId && durationValidity)
                {
                    Console.WriteLine("Your Entry is Valid");
                }
            }
            catch(InvalidEntryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}