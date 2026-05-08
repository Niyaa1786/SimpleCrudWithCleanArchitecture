using FluentValidation;
using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Exceptions;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Application.Mapper;
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

        public async Task<CategoryDto> ExecuteAsync(Guid id, UpdateCategoryRequest request, CancellationToken cancellationToken = default)
        {
            _validator.ValidateAndThrow(request);
            var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
            if (category == null) throw new NotFoundException($"Category with ID {id} not found.");

            CategoryMapper.ApplyUpdates(request,category);
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return CategoryMapper.ToDto(category);
        }
    }
}
