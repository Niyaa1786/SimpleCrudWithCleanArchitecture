    using FluentValidation;
using FluentValidation.Results;
using SimpleCrud.Application.DTOs;
    using SimpleCrud.Application.DTOs.Request;
    using SimpleCrud.Application.Interfaces;
    using SimpleCrud.Application.Validators;
    using SimpleCrud.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace SimpleCrud.Application.UseCases.Categories
    {
        public class CreateCategory
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IValidator<CreateCategoryRequest> _validator;
            public CreateCategory(IUnitOfWork unitOfWork, IValidator<CreateCategoryRequest> validator)
            {
                _unitOfWork = unitOfWork;
                _validator = validator;
            }

            public async Task<CategoryDto> ExecuteAsync(CreateCategoryRequest request, CancellationToken cancellationToken = default)
            {
                _validator.ValidateAndThrow(request);
                var existingCategory = await _unitOfWork.Categories.ExistByNameAsync(request.Name, cancellationToken);

                if (existingCategory)
                {
                    var failure = new ValidationFailure(nameof(request.Name), "Category name must be unique.");
                    throw new ValidationException(new[] { failure });
                }

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
