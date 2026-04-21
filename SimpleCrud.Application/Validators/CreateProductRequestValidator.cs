using FluentValidation;
using SimpleCrud.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");
        }
    }
}
