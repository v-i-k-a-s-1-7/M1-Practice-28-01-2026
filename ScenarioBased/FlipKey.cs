using System;
using System.Text;

namespace M1_Practice
{
    /// <summary>
    /// Main program class for generating FlipKey encryption keys.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Cleanses and inverts a string input to generate an encrypted key.
        /// Process: validate → convert to lowercase → filter odd ASCII chars → reverse → capitalize alternating chars
        /// </summary>
        /// <param name="input">The input string to process (must be at least 6 characters and contain only letters)</param>
        /// <returns>The processed key, or empty string if validation fails</returns>
        public string CleanseAndInvert(string input)
        {
            // Validate input is not null/empty and has minimum length of 6 characters
            if (string.IsNullOrEmpty(input) || input.Length < 6)
            {
                return string.Empty;
            }

            // Verify all characters in input are letters only
            foreach (char item in input)
            {
                if (!char.IsLetter(item))
                {
                    return string.Empty;
                }
            }

            // Convert entire string to lowercase for processing
            string lower = input.ToLower();
            StringBuilder filtered = new StringBuilder();

            // Filter characters: keep only those with odd ASCII values
            foreach (char item in lower)
            {
                if (((int)item) % 2 != 0)
                {
                    filtered.Append(item);
                }
            }

            // Reverse the filtered string
            char[] reversed = filtered.ToString().ToCharArray();
            Array.Reverse(reversed);

            // Capitalize characters at even positions (0, 2, 4, etc.)
            for (int i = 0; i < reversed.Length; i++)
            {
                if (i % 2 == 0)
                {
                    reversed[i] = char.ToUpper(reversed[i]);
                }
            }

            return new string(reversed);
        }

        /// <summary>
        /// Main entry point for the FlipKey application.
        /// Prompts user for input and generates an encrypted key.
        /// </summary>
        private static void Main(string[] args)
        {
            // Display prompt to user
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();

            // Create program instance and process the input
            Program program = new Program();
            string result = program.CleanseAndInvert(input);

            // Display result or error message based on validation
            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine($"The generated key is - {result}");
            }
        }
    }
}