using System;
using System.Collections.Generic;
using System.Linq;


public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();
    
    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        if(_products.Any(p => p.Id == product.Id))
            throw new Exception("Invalid product ID");
        
        if(product.Price <= 0)
            throw new Exception("Invalid Price");
        
        if(string.IsNullOrEmpty(product.Name))
            throw new Exception("Invalid Name");
          
        _products.Add(product);
    }
    
    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        return _products.Where(predicate);
    }
    
    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        decimal total = 0;
        
        foreach(var item in _products){
          
          total += item.Price;
        }
        
        return total;
    }
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        if(discountPercentage < 0 || discountPercentage >100)
            throw new Exception("Invalid Discount");
        
        _product = product;
        _discountPercentage = discountPercentage;
        
    }
    
    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
    
    // TODO: Override ToString to show discount details
    
    public override string ToString(){
        return $"product : {_product.Name}"+
               $"Original Price: {_product.Price}, " +
               $"Discount: {_discountPercentage}%, " +
               $"Final Price: {DiscountedPrice}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        foreach(var item in products)
        {
            System.Console.WriteLine($"{item.Name} - {item.Price}");
        }
        // b) Find the most expensive product
        
        // c) Group products by category
        // d) Apply 10% discount to Electronics over $500

        
        
    }
    
    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully
    }
}

// 5. TEST SCENARIO: Your tasks:
// a) Implement all TODO methods with proper error handling
// b) Create a sample inventory with at least 5 products
// c) Demonstrate:
//    - Adding products with validation
//    - Finding products by brand (for electronics)
//    - Applying discounts
//    - Calculating total value before/after discount
//    - Handling a mixed collection of different product types
