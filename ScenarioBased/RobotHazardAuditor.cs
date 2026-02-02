using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace M1_Practice{

    /// <summary>
    /// Custom exception class for robot safety-related errors.
    /// Inherits from Exception to provide specialized error handling for the auditor system.
    /// </summary>
    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message): base(message)
        {
            
        }
    }
    /// <summary>
    /// Class responsible for auditing and calculating robot hazard risk based on various factors.
    /// </summary>
    public class RobotHazardAuditor
    {
        /// <summary>
        /// Calculates the hazard risk score for a robot based on arm precision, worker density, and machinery state.
        /// </summary>
        /// <param name="armPrecision">Decimal value between 0.0 and 1.0 representing the robot arm's precision accuracy</param>
        /// <param name="workerDensity">Integer between 1 and 20 representing the number of workers in proximity</param>
        /// <param name="machineryState">String indicating machinery condition: "Worn", "Faulty", or "Critical"</param>
        /// <returns>A double representing the calculated hazard risk score</returns>
        /// <exception cref="RobotSafetyException">Thrown when any input parameter is invalid</exception>
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            // Validate arm precision is within acceptable range (0.0 to 1.0)
            if(armPrecision < 0.0 || armPrecision > 1.0)
            {
                throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");
            }

            // Validate worker density is within acceptable range (1 to 20)
            if(workerDensity < 1 || workerDensity > 20)
            {
                throw new RobotSafetyException("Error: Worker density must be 1-20");
            }

            // Validate machinery state is one of the accepted values
            if(machineryState != "Worn" && machineryState != "Faulty" && machineryState != "Critical")
            {
                throw new RobotSafetyException("Error: Unsupported machinery state");
            }

            // Assign risk multiplier based on machinery state using switch expression
            double machineRiskFactor = machineryState switch
            {
                "Worn" => 1.3,         // Worn machinery has minimal risk increase
                "Faulty" => 2.0,       // Faulty machinery has moderate risk increase
                "Critical" => 3.0,     // Critical machinery has maximum risk increase
    
            };

            // Calculate final hazard risk: lower precision increases risk, higher worker density increases risk
            double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);

            return hazardRisk;

        }
    }

    /// <summary>
    /// Main entry point for the Robot Hazard Auditor application.
    /// Prompts user for input and calculates the hazard risk score.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an instance of the RobotHazardAuditor
            RobotHazardAuditor robot1 = new RobotHazardAuditor();

            // Prompt user for arm precision input
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = double.Parse(Console.ReadLine());

            // Prompt user for worker density input
            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = int.Parse(Console.ReadLine());

            // Prompt user for machinery state input
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            // Try to calculate hazard risk, catching any safety exceptions
            try
            {
                double hazardRisk = robot1.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
                Console.WriteLine($"Robot Hazard Risk Score: {hazardRisk}");
            }
            catch(RobotSafetyException ex)
            {
                // Display error message if input validation fails
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}