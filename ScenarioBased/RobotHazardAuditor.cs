using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace M1_Practice{


    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message): base(message)
        {
            
        }
    }
    public class RobotHazardAuditor
    {
        
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            if(armPrecision < 0.0 || armPrecision > 1.0)
            {
                throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");
            }

            if(workerDensity < 1 || workerDensity > 20)
            {
                throw new RobotSafetyException("Error: Worker density must be 1-20");
            }
            if(machineryState != "Worn" && machineryState != "Faulty" && machineryState != "Critical")
            {
                throw new RobotSafetyException("Error: Unsupported machinery state");
            }

            double machineRiskFactor = machineryState switch
            {
                "Worn" => 1.3,
                "Faulty" => 2.0,
                "Critical" => 3.0,
                 _ => throw new RobotSafetyException("Invalid machinery state")
            };

            double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);

            return hazardRisk;

        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            RobotHazardAuditor robot1 = new RobotHazardAuditor();

            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            try
            {
                double hazardRisk = robot1.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
                Console.WriteLine($"Robot Hazard Risk Score: {hazardRisk}");
            }
            catch(RobotSafetyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}