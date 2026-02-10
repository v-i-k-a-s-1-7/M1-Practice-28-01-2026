using System.ComponentModel;

namespace StringExercises
{
    
    public class DecodePattern
    {
        
        public static void Main(string[] args)
        {
            int num;
            int.TryParse(Console.ReadLine(),out num);

            for(int i = 1; i<= num; i++)
            {
                if(i % 2 != 0)
                {
                    for(int j = 1; j< num; j++)
                    {
                        Console.Write($"{i} ");
                    }
                    int newVar = i + 1;
                    Console.Write($"{newVar}");
                    Console.WriteLine();
                }
                else
                {
                    int newVar = i+1;
                    Console.Write($"{newVar} ");
                    for(int k = 1; k<= num - 1 ; k++)
                    {
                        Console.Write($"{i} ");
                    }
                    Console.WriteLine();
                }
                
            }

        }
    }

}