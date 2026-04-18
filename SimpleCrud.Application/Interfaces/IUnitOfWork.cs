using SimpleCrud.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    }
}
