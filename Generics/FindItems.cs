using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // In your template this is already provided.
    public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>()
    {
        { "Pen", 120 },
        { "Pencil", 80 },
        { "Notebook", 250 },
        { "Eraser", 60 }
    };

    // 1) Find items by sold count (value)
    public SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string,long> soldCountMatch = new SortedDictionary<string,long>();
        foreach(var item in itemDetails){
          
          if(item.Value == soldCount)
            soldCountMatch[item.Key] = item.Value;
        }
        return soldCountMatch;
    }

    // 2) Find min and max sold item names (min first, max second)
    public List<string> FindMinandMaxSoldItems()
    {
        var max = long.MinValue;
        var min = long.MaxValue;
        var maxName = "";
        var minName = "";
        List<string> minMax = new List<string>();
        
        foreach(var item in itemDetails){
          
          if(item.Value > max)
          {
            max = item.Value;
            maxName = item.Key;
          }
          if(item.Value < min)
          {
            min = item.Value;
            minName = item.Key;
          } 
        }
          minMax.Add(minName);
          minMax.Add(maxName);
          
          return minMax;
    }

    // 3) Sort all items by sold count and return as Dictionary
    public Dictionary<string, long> SortByCount()
    {
       Dictionary<string,long> newDictonary = new Dictionary<string,long>();
       newDictonary = itemDetails.OrderBy(e=> e.Value).ToDictionary(e => e.Key , e=> e.Value);
       return newDictonary;
    }

    // Sample Main to test
    public static void Main()
    {
        Program p = new Program();

        Console.Write("Enter sold count to search: ");
        long soldCount = long.Parse(Console.ReadLine());

        var found = p.FindItemDetails(soldCount);
        if (found.Count == 0)
        {
            Console.WriteLine("Invalid sold count");
        }
        else
        {
            foreach (var kv in found)
                Console.WriteLine($"{kv.Key} : {kv.Value}");
        }

        var minMax = p.FindMinandMaxSoldItems();
        if (minMax.Count >= 2)
            Console.WriteLine($"Min Sold Item: {minMax[0]}, Max Sold Item: {minMax[1]}");

        Console.WriteLine("Sorted by sold count:");
        var sorted = p.SortByCount();
        foreach (var kv in sorted)
            Console.WriteLine($"{kv.Key} : {kv.Value}");
    }
}