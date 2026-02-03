using System;
using System.Security.Cryptography.X509Certificates;

namespace Sample
{
    public class Program
    {

        public static void Main(string[] args)
        {   

        SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();
    
        Console.WriteLine("======Enter Your Choice==========");
        Console.WriteLine("1. Add Bike Details");
        Console.WriteLine("2. Group Bikes By Brand");
        Console.WriteLine("3. Exit");
        int choice = int.Parse(Console.ReadLine());

        BikeUtility bike1 = new BikeUtility();

            bool flag = true;

            while(flag){
                switch (choice)
                {
                    case 1: 
                        Console.WriteLine("Enter the Model");
                        string model = Console.ReadLine();

                        Console.WriteLine("Enter Brand Name");
                        string brand = Console.ReadLine();

                        Console.WriteLine("Enter the Price Per Day");
                        int price = int.Parse(Console.ReadLine());

                        bike1.AddBikeDetails(model,brand,price);

                        Console.WriteLine("Bike added Successfully");

                        Console.WriteLine("======Enter Your Choice==========");
                        Console.WriteLine("1. Add Bike Details");
                        Console.WriteLine("2. Group Bikes By Brand");
                        Console.WriteLine("3. Exit");
                        break;
                    
                    case 2:
                        // bike1.GroupBikesByBrand();
                        break;
                    
                    case 3:
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        } 
    }
}