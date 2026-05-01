using SimpleCrud.Application.Interfaces;
using SimpleCrud.Domain.Interfaces;
    using SimpleCrud.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace SimpleCrud.Infrastructure.Repositories
    {
        public class UnitOfWork : IUnitOfWork
    {
            private readonly AppDbContext _context;
            private IProductRepository? _productRepository;
            private ICategoryRepository? _categoryRepository;

            public UnitOfWork(AppDbContext context) => _context = context;

            public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
            public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

            public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);
        }
    }
