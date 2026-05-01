using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.UseCases.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Facade
{
    public interface IProductFacade
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct);
        Task<IEnumerable<ProductDto>> GetAllByCategory(Guid id, CancellationToken ct);
        Task<ProductDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<ProductDto> CreateAsync(CreateProductRequest request, CancellationToken ct);
        Task<ProductDto> UpdateAsync(Guid id, UpdateProductRequest request, CancellationToken ct);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct);

    }
}
