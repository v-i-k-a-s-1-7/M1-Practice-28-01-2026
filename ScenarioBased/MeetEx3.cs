namespace ScenarioBased{


    public class InvalidCreditDataException : Exception
    {
        public InvalidCreditDataException(string message) : base(message)
        {
            
        }
    }
    public class CreditRiskProcessor
    {
        
        public bool validateCustomDetails(int age, string employmentType, double monthlyIncome, double dues, int creditScore, int defaults)
        {
            if(age < 21 || age > 65)
                throw new InvalidCreditDataException("Invalid Age");
            
            if(!(employmentType.ToLower() == "salaried" || employmentType.ToLower() == "Self-Employed"))
                throw new InvalidCreditDataException("Invalid Employment Type");

            if(monthlyIncome < 20000)
                throw new InvalidCreditDataException("Invalid Monthly Income");
            
            if(!(dues >= 0))
                throw new InvalidCreditDataException("Invalid Credit dues");

            if(creditScore < 300 && creditScore > 900)
                throw new InvalidCreditDataException("Invalid Credit Score");
            
            if(defaults > 0)
                throw new InvalidCreditDataException("Invalid Default Count");
            
            return true;

        }

        public double calculateCreditLimit(double monthlyIncome, double dues, int creditScore, int defaults)
        {
            
            double debtRatio = dues / (monthlyIncome * 12);

            if(creditScore < 600  || defaults >= 3 || debtRatio > 0.4)
                return 50000;
            
            if((creditScore >= 600 && creditScore < 749) || (defaults <= 2 && defaults > 0))
                return 150000;

            if(creditScore >= 750 && defaults== 0 && debtRatio < 0.25)
                return 300000;

            return 0;
        }

    }

    public class UserInterface
    {
        public static void Main(string[] args)
        {
            try
            {

                System.Console.WriteLine("Enter Customer Name");
                string customerName = Console.ReadLine();

                System.Console.WriteLine("Enter Customer Age");
                int customerAge = int.Parse(Console.ReadLine());

                System.Console.WriteLine("Enter Employment Type");
                string employmentType = Console.ReadLine();

                System.Console.WriteLine("Enter Monthly Income");
                double monthlyIncome = double.Parse((Console.ReadLine()));
                
                System.Console.WriteLine("Existing Credit Card Dues");
                int dues = int.Parse((Console.ReadLine()));

                System.Console.WriteLine("Existing Credit Score");
                int creditScore = int.Parse((Console.ReadLine()));

                System.Console.WriteLine("Number of Loan Defaults");
                int defaults = int.Parse((Console.ReadLine()));

                CreditRiskProcessor cus1 = new CreditRiskProcessor();
                cus1.validateCustomDetails(customerAge,employmentType,monthlyIncome,dues,creditScore,defaults);

                double res = cus1.calculateCreditLimit(monthlyIncome,dues,creditScore,defaults);

                System.Console.WriteLine($"Your Credit Limit is : {res}");
            
            }
            catch(InvalidCreditDataException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
    }
}