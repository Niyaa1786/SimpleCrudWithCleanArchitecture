using FluentValidation;
using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Exceptions;
using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Categories
{
    public class UpdateCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateCategoryRequest> _validator;

        public UpdateCategory(IUnitOfWork unitOfWork, IValidator<UpdateCategoryRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<CategoryDto> ExecuteAsync(Guid id, string name, CancellationToken cancellationToken = default)
        {
            _validator.ValidateAndThrow(new UpdateCategoryRequest { Name = name });
            var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
            if (category == null) throw new NotFoundException($"Category with ID {id} not found.");

            category.Update(name);
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ProductCount = category.Products.Count(),
            };
        }
    }
}
