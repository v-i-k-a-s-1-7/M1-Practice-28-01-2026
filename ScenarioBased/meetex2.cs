using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        Console.WriteLine(CountDeletions(word1, word2));
    }

    static int CountDeletions(string word1, string word2)
    {
        Dictionary<char, int> freq1 = new Dictionary<char, int>();
        Dictionary<char, int> freq2 = new Dictionary<char, int>();

        
        foreach (char item in word1)
        {
            if (freq1.ContainsKey(item))
                freq1[item]++;
            else
                freq1[item] = 1;
        }

        
        foreach (char item in word2)
        {
            if (freq2.ContainsKey(item))
                freq2[item]++;
            else
                freq2[item] = 1;
        }

        int deletions = 0;

        
        foreach (var item in freq1)
        {
            int countInWord2 = freq2.ContainsKey(item.Key) ? freq2[item.Key] : 0;
            deletions += Math.Abs(item.Value - countInWord2);
        }

        foreach (var item in freq2)
        {
            if (!freq1.ContainsKey(item.Key))
            {
                deletions += item.Value;
            }
        }

        return deletions;
    }
}
