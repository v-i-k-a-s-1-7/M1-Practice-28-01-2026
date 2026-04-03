using System;
using System.Linq;
using System.Collections.Generic;


namespace HelloWorld{
  
  public class Program{
    
    public static void Main(string[] args){
      
      LinkedList<int> link = new LinkedList<int>();
      
      // Exercise 1
      link.AddLast(100);
      link.AddLast(10);
      link.AddLast(20);
      link.AddLast(30);
      link.AddLast(40);
      
      
      // Exercise 2
      link.AddFirst(5);
      
      // Exercise 3
      link.AddLast(25);
      
      // Exercise 4
      var node = link.Find(20);
      link.AddAfter(node,25);
      
      //Exercise 5
      link.AddBefore(node,15);
      
      //Exercise 6
      link.Remove(15); // removes the first occurence of 15
      
      //Exercise 7
      link.RemoveFirst();
      link.RemoveLast();
      
      //Exercise 8
      LinkedListNode<int> current = link.Last;
      
      while( current != null){
        Console.Write($"{current.Value} ");
        current = current.Previous;
      }
      Console.WriteLine();
      
      current = link.First;
      while(current != null){
        Console.Write($"{current.Value} ");
        current = current.Next;
      }
      Console.WriteLine();
      
      // Exercise 9
      int max = link.Max();
      Console.WriteLine($"Max: {max}");
      
      int min = link.Min();
      Console.WriteLine($"Min: {min}");
      
      // Exercise 10
      var evenList = link.Select(e=> e).Where(e=> e%2 == 0);
      int evenCount = evenList.Count();
      
      Console.WriteLine($"Even Elements: {evenCount}");
      
      // Exercise 11
      var sumOfElements = link.Sum();
      Console.WriteLine($"Sum of Elemets: {sumOfElements}");
      
      // Exercise 12
      current = link.First;
      while(current != null){
        Console.Write($"{current.Value} ");
        current = current.Next;
      }
      Console.WriteLine();
      
      // reverse
      current = link.Last;
      while(current != null){
          Console.Write($"{current.Value} ");
          current = current.Previous;
      }
      
      Console.WriteLine();
      
      var revList = link.Reverse();
      
      foreach(var item in revList){
        Console.Write($"{item} ");
      }
      
        Console.WriteLine();
      
      var firstIndex = link.First;
      int middleIndex = (link.Count)/2;
      int count = 0;
      while(count < middleIndex){
        Console.Write($"{firstIndex.Value} ");
        firstIndex = firstIndex.Next;
        count++;
      }
      
      for(int i = 0; i< middleIndex; i++){
        
      }
      
      Console.WriteLine();
      foreach(var item in link){
        Console.Write($"{item} ");
      }
    }
  }
}