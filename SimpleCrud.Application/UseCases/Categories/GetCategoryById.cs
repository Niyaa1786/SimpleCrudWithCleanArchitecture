using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Categories
{
    public class GetCategoryById
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryById(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<CategoryDto> ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductCount = category.Products.Count(),
            };
        }
    }
}
