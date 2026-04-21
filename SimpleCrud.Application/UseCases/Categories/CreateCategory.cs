using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Categories
{
    public class CreateCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCategory(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<CategoryDto> ExecuteAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrEmpty(request.Name))
                throw new ArgumentException("Category name cannot be null or empty.");

            var category = new Category(request.Name);

            _unitOfWork.Categories.Add(category);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductCount = 0
            };
        }
    }
}
