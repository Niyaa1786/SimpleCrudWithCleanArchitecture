using Microsoft.EntityFrameworkCore;
using SimpleCrud.Domain.Entities;
using SimpleCrud.Domain.Interfaces;
using SimpleCrud.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task<bool> ExistByNameAsync(string name, CancellationToken cancellationToken = default)
            => await _context.Products.AnyAsync(p => p.Name == name, cancellationToken);

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Products.AsNoTracking().Include(c => c.Category).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Product>> GetAllByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default)
            => await _context.Products
            .AsNoTracking()
            .Include(c => c.Category)
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync(cancellationToken);

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Products
            .Include(c => c.Category)
            .FirstOrDefaultAsync(p => p.Id == id,cancellationToken);
        public void Add(Product product) => _context.Products.Add(product);

        public void Delete(Product product) => _context.Products.Remove(product);
        public void Update(Product product) => _context.Products.Update(product);
    }
}
