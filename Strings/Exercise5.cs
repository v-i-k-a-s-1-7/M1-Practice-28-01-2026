// prompt: First and only line of the input consists of a binary string S, which describes a
// match. '0' means Peter lose a point, whereas '1' means he won the point.
// Output Format
// Output on a separate line a string describing who won the match. If Peter won
// then print "Win" (without quotes), otherwise print "Lose" (without quotes).

namespace StringExercises
{
    
    public class WhoWon
    {
        
        public bool DetermineWhoWon(string s)
        {
            int countZero = 0;
            int countOne = 0;
            foreach(var item in s)
            {
                if(item == '0')
                {
                    countZero++;
                }
                else
                {
                    countOne++;
                }
            }

            return countOne > countZero ? true : false ; 

        }
    }

    public class Program
    {
        
        public static void Main(string[] args)
        {
            WhoWon peterWonOrNot = new WhoWon();

            bool res = peterWonOrNot.DetermineWhoWon("010100000");

           System.Console.WriteLine(res ? "Win" : "Lost");
        }
    }
}