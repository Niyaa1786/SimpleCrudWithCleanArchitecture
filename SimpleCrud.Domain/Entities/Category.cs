using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }= string.Empty;
        private List<Product> _products = new();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        private Category() { }

        public void Update(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            
            Name = name;
        }




    }
}
