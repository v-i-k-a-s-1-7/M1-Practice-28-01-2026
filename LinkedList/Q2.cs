using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class RemoveDuplicates
    {
        public LinkedList<int> uniqueLL(LinkedList<int> link)
        {
            LinkedList<int> unique = new LinkedList<int>();
            foreach(var item in link)
            {
                if (unique.Contains(item))
                {
                    continue;
                }
                else
                {
                    unique.AddLast(item);
                }
            }

            return unique;
        }
    }

    public class Program
    {
        public static void Main()
        {
            LinkedList<int> link = new LinkedList<int>();

            link.AddLast(10);
            link.AddLast(20);
            link.AddLast(10);
            link.AddLast(30);
            link.AddLast(10);
            link.AddLast(40);
            link.AddLast(10);
            link.AddLast(50);
            foreach( var item in link)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            RemoveDuplicates removeDuplicates = new RemoveDuplicates();
            var res = removeDuplicates.uniqueLL(link);

            foreach( var item in res)
            {
                Console.Write($"{item} ");
            }
        }
    }
}