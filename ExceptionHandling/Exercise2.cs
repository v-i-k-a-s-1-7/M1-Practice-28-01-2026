using System.Runtime.CompilerServices;

namespace ExceptionHandling{
    
    public class InvalidGadgetException : Exception
    {
        public InvalidGadgetException(string message) : base(message)
        {
            
        }
    }
    public class GadgetValidatorUtil
    {
        public bool ValidateGadgetID(string gadgetID)
        {
            char firstLetter = gadgetID[0];
            if (!char.IsUpper(firstLetter))
            {
                 throw new InvalidGadgetException("Invalid gadget Id");
            }

            string firstThreeNumbers = gadgetID.Substring(1,3);
            foreach(char item in firstThreeNumbers)
            {
                if (!char.IsDigit(item))
                {
                    throw new InvalidGadgetException("Invalid gadget Id");
                }
            }

            return true;
        }

          public bool ValidateWarrantyPeriod(int period)
        {
            if(period > 36 || period < 6)
            {
                throw new InvalidGadgetException("Invalid warranty period");
            }

            return true;
        }
    }

    public class Program3
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] parts = input.Split(':');

            string gadgetId = parts[0];
            string gadgetType = parts[1];
            int warrantyPeriod = int.Parse(parts[2]);

            GadgetValidatorUtil GV1 = new GadgetValidatorUtil();

            if (GV1.ValidateGadgetID(gadgetId) && GV1.ValidateWarrantyPeriod(warrantyPeriod))
                Console.WriteLine("Warranty accepted, stock updated");

        }
    }
}