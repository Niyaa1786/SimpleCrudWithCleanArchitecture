using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, decimal price, Guid categoryId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public Product() { }

        public void Update(string name, decimal price, Guid categoryId)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (price < 0)
                throw new ArgumentOutOfRangeException("Price cannot be negative.");
            
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }
    }
}
