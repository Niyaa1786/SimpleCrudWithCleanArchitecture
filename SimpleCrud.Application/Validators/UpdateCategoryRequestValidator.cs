using FluentValidation;
using SimpleCrud.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Validators
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required.");
        }
    }
}
