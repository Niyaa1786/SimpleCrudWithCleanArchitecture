using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Categories
{
    public class UpdateCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategory(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<CategoryDto> ExecuteAsync(Guid id, string name, CancellationToken cancellationToken = default)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
            if (category == null) return null;

            category.Update(name);
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductCount = category.Products.Count(),
            };
        }
    }
}
