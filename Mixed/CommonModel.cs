using System;
using System.Collections.Generic;
using System.Linq;

namespace Mixed
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }

    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; set; }
        Category Category { get; }
    }

    public enum Category
    {
        Electronics,
        Clothing,
        Books,
        Groceries
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }

}