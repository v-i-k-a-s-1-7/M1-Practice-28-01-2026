namespace Meeting
{
    
    public class Program1
    {
        
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a String");
            string s1 = Console.ReadLine();

            SortedDictionary<char,int> frequency = new SortedDictionary<char, int>();
            foreach(var item in s1)
            {
                if (frequency.ContainsKey(item))
                {
                    frequency[item] += 1;
                }
                else
                {
                    frequency[item] = 1;
                }
            }

            foreach(var item in frequency)
            {
                Console.WriteLine(item);
            }
        }
    }
}