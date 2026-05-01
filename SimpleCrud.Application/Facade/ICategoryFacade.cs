using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Facade
{
    public interface ICategoryFacade
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken ct);
        Task<CategoryDto> GetByIdAsync(Guid id, CancellationToken ct);
        Task<CategoryDto> CreateAsync(CreateCategoryRequest request, CancellationToken ct);
        Task<CategoryDto> UpdateAsync(Guid id,UpdateCategoryRequest request, CancellationToken ct);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct);
    }
}
