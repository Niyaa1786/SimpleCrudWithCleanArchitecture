using SimpleCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId);
        Task<Product> GetByIdAsync(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);


    }
}
