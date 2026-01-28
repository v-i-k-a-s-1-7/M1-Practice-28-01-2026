using System;

namespace ExceptionHandling
{
    /// <summary>
    /// Exception thrown when an entry is invalid according to business rules.
    /// </summary>
    public class InvalidEntryException : Exception
    {
        /// <summary>
        /// Create a new <see cref="InvalidEntryException"/> with the specified message.
        /// </summary>
        public InvalidEntryException(String message): base(message)
        {
        }
    }  

    /// <summary>
    /// Utility methods for validating entries such as employee IDs and durations.
    /// </summary>
    public class EntryUtility
    {
        /// <summary>
        /// Validate an employee id using the expected format: "GOAIR/NNNN"
        /// where the total length is 10 characters, the prefix is "GOAIR",
        /// a slash follows the prefix, and the last 4 characters are digits.
        /// </summary>
        /// <param name="employeeId">The employee id to validate.</param>
        /// <returns>True if the id is valid; otherwise an exception is thrown.</returns>
        public bool validateEmployeeId(string employeeId)
        {
            // Ensure the provided string has the exact expected length
            int lengthOfString = employeeId.Length;

            if(lengthOfString != 10)
            {
                throw new InvalidEntryException("Invalid Entry");
            }

            // Extract the first five characters to verify the prefix
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

            // Check that position 6 is a slash
            string slashPresence = employeeId.Substring(5,1);

            if(slashPresence != "/")
            {
                throw new InvalidEntryException("Invalid Entry");
            }

            // Ensure the last 4 characters are digits
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

        /// <summary>
        /// Validate the duration value is within allowed range (1-5 inclusive).
        /// </summary>
        /// <param name="duration">Duration to validate.</param>
        /// <returns>True if duration is within range; otherwise throws <see cref="InvalidEntryException"/>.</returns>
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

    /// <summary>
    /// Program entry used to prompt the user for inputs and validate them
    /// using the <see cref="EntryUtility"/> methods.
    /// </summary>
    public class Program2
    {
        /// <summary>
        /// Reads user input for employee id, entry type and duration, then
        /// validates the input. Validation errors are exposed via
        /// <see cref="InvalidEntryException"/> and reported to the console.
        /// </summary>
        public static void Main(string[] args)
        {
            // Prompt for employee id and read user input
            Console.WriteLine("Enter your Employee Id");
            string EmpId = Console.ReadLine();

            // Prompt for entry type (not validated in current implementation)
            Console.WriteLine("Enter Your Entry Type");
            string EntryType = Console.ReadLine();

            // Prompt for duration and parse as integer
            Console.WriteLine("Enter Duration");
            int duration = int.Parse(Console.ReadLine());

            EntryUtility eu = new EntryUtility();

            try
            {
                // Validate employee id and duration using utility methods
                bool validityId = eu.validateEmployeeId(EmpId);
                bool durationValidity = eu.validateDuration(duration);

                if (validityId && durationValidity)
                {
                    Console.WriteLine("Your Entry is Valid");
                }
            }
            catch(InvalidEntryException ex)
            {
                // Report validation error message to the user
                Console.WriteLine(ex.Message);
            }
        }
    }
}