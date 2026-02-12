namespace ScenarioBased
{
    // Base product interface
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; set; }
        Category Category { get; }

    }

    public enum Category { Electronics, Clothing, Books, Groceries }
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();
        
        // TODO: Implement method to add product with validation
        public void AddProduct(T product)
        {
            if (product == null)
                throw new ArgumentNullException();

            if (_products.Any(p => p.Id == product.Id))
                throw new InvalidOperationException("Duplicate product Id");
            
            if(product.Price < 0)
                throw new Exception("Price Cannot be Negative");

            _products.Add(product);

        }

        // TODO: Create method to find products by predicate
        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            // Should return filtered products
            return _products.Where(predicate);

        }

            // TODO: Calculate total inventory value
        public decimal CalculateTotalValue()
        {
            // Return sum of all product prices
            return _products.Sum(p => p.Price);

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
        public override string ToString()
        {
            return $"{_product.Name} | Original: {_product.Price} | Discount: {_discountPercentage}% | Final: {DiscountedPrice}";
        }
        
        public DiscountedProduct(T product, decimal discountPercentage)
        {
            // TODO: Initialize with validation
            // Discount must be between 0 and 100
            if (product == null)
                throw new ArgumentNullException();

            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentException("Invalid discount");

            _product = product;
            _discountPercentage = discountPercentage;

        }
        
        // TODO: Implement calculated price with discount
        public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
        
        // TODO: Override ToString to show discount details
    }

    public class InventoryManager
    {
        // TODO: Create method that accepts any IProduct collection
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            
            // a) Print all product names and prices
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }

            // b) Find the most expensive product
            var expensive = products.OrderByDescending(p => p.Price).FirstOrDefault();

            // c) Group products by category
            var grouped = products.GroupBy(p => p.Category);

            // d) Apply 10% discount to Electronics over $500
            var discounted = products.Where(p => p.Category == Category.Electronics && p.Price > 500).Select(p => new DiscountedProduct<IProduct>(p, 10));

        }
        
        // TODO: Implement bulk price update with delegate
        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
            where T : IProduct
        {
            // Apply priceAdjuster to each product
            // Handle exceptions gracefully
            foreach (var p in products)
            {
                try
                {
                    var newPrice = priceAdjuster(p);
                    p.Price = newPrice;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating {p.Name}: {ex.Message}");
                }
            }

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

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create repository
                var electronicRepo = new ProductRepository<ElectronicProduct>();

                // Add products
                electronicRepo.AddProduct(new ElectronicProduct
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 800,
                    Brand = "Dell",
                    WarrantyMonths = 24
                });

                electronicRepo.AddProduct(new ElectronicProduct
                {
                    Id = 2,
                    Name = "Smart TV",
                    Price = 1200,
                    Brand = "Samsung",
                    WarrantyMonths = 12
                });

                electronicRepo.AddProduct(new ElectronicProduct
                {
                    Id = 3,
                    Name = "Headphones",
                    Price = 150,
                    Brand = "Sony",
                    WarrantyMonths = 6
                });

                // 3️⃣ Calculate total value
                Console.WriteLine("Total Inventory Value:");
                Console.WriteLine(electronicRepo.CalculateTotalValue());

                Console.WriteLine("\n--------------------------------");

                // 4️⃣ Find products by brand
                Console.WriteLine("Products by Brand: Dell");
                var dellProducts = electronicRepo
                    .FindProducts(p => p.Brand == "Dell");

                foreach (var product in dellProducts)
                {
                    Console.WriteLine($"{product.Name} - {product.Price}");
                }

                Console.WriteLine("\n--------------------------------");

                // 5️⃣ Apply discount
                Console.WriteLine("Applying 10% Discount on Electronics over $500");

                var expensiveElectronics = electronicRepo
                    .FindProducts(p => p.Price > 500);

                foreach (var product in expensiveElectronics)
                {
                    var discounted = new DiscountedProduct<ElectronicProduct>(product, 10);
                    Console.WriteLine(discounted.ToString());
                }

                Console.WriteLine("\n--------------------------------");

                // 6️⃣ Mixed Collection Demonstration
                var mixedProducts = new List<IProduct>
                {
                    new ElectronicProduct
                    {
                        Id = 4,
                        Name = "Gaming Console",
                        Price = 600,
                        Brand = "Sony",
                        WarrantyMonths = 18
                    },
                    new ElectronicProduct
                    {
                        Id = 5,
                        Name = "Camera",
                        Price = 950,
                        Brand = "Canon",
                        WarrantyMonths = 12
                    }
                };

                var manager = new InventoryManager();
                manager.ProcessProducts(mixedProducts);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }


    }

