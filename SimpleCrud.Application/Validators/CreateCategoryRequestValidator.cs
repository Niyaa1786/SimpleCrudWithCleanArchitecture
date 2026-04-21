using FluentValidation;
using SimpleCrud.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required.");
        }
    }
}
