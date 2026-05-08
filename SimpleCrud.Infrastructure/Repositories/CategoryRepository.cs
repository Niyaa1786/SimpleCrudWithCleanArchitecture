using Microsoft.EntityFrameworkCore;
using SimpleCrud.Domain.Entities;
using SimpleCrud.Domain.Interfaces;
using SimpleCrud.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<bool> ExistByNameAsync(string name, CancellationToken cancellationToken = default)
            => await _context.Categories.AnyAsync(c => c.Name == name, cancellationToken);

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Categories
                .AsNoTracking()
                .Include(e => e.Products)
                .ToListAsync(cancellationToken);

        public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Categories
                .Include(e => e.Products)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public void Add(Category category) => _context.Categories.Add(category);
        public void Update(Category category) => _context.Categories.Update(category);
        public void Delete(Category category) => _context.Categories.Remove(category);
    }
}
