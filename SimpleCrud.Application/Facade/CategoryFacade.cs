using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.UseCases.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Facade
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly CreateCategory _createCategory;
        private readonly UpdateCategory _updateCategory;
        private readonly DeleteCategory _deleteCategory;
        private readonly GetAllCategories _getAllCategories;
        private readonly GetCategoryById _getCategoryById;

        public CategoryFacade(
            CreateCategory createCategory,
            UpdateCategory updateCategory,
            DeleteCategory deleteCategory,
            GetAllCategories getAllCategories,
            GetCategoryById getCategoryById)
        {
            
        }
        public Task<CategoryDto> CreateAsync(CreateCategoryRequest request, CancellationToken ct)
        {
            return _createCategory.ExecuteAsync(request, ct);
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            return _deleteCategory.ExecuteAsync(id, ct);
        }

        public Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken ct)
        {
            return _getAllCategories.ExecuteAsync(ct);
        }

        public Task<CategoryDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return _getCategoryById.ExecuteAsync(id, ct);
        }

        public Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryRequest request, CancellationToken ct)
        {
            return _updateCategory.ExecuteAsync(id, request, ct);
        }
    }
}
