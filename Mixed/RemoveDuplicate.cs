namespace Mixed
{
    
    public class Program
    {
        
        public static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            input = input.Replace("[","");
            input = input.Replace("]","");
            input = input.Trim();
            string[] Ids = input.Split(",");

            List<int> ints = new List<int>();
            List<int> uniqueInts = new List<int>();

            foreach(var id in Ids)
            {
                ints.Add(int.Parse(id));   
            }

            foreach(var id in ints){
                if(uniqueInts.Contains(id))
                    continue;
                uniqueInts.Add(id);
            }

            string res = string.Join(",", uniqueInts);
            System.Console.WriteLine(res);
        }
    }
}