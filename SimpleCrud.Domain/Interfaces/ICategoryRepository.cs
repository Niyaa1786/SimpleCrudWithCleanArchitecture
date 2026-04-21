using SimpleCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
