using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Price { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Name = "Laptop", Category = "Electronics", Price = 60000 },
            new Product { Name = "Phone", Category = "Electronics", Price = 40000 },
            new Product { Name = "Book", Category = "Books", Price = 500 },
            new Product { Name = "Notebook", Category = "Books", Price = 300 }
        };

        // TODO:
        // Group by Category
        var groupByCategory = products.GroupBy(p=> p.Category)
                                        .Select(g=> new
                                        {
                                            Category = g.Key,
                                            HighestPrice = g.Max(s=> s.Price)
                                        });
        // Print highest price per category
        foreach(var group in groupByCategory)
        {
            System.Console.WriteLine($"{group.Category} -> {group.HighestPrice}");
        }
    }
}
