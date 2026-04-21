using FluentValidation;
using SimpleCrud.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SimpleCrud.Application.Validators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.");
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.")
                .InclusiveBetween(1000, 10000000).WithMessage("Price must be between 1000 and 10000000.");
            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("CategoryId is required.");
        }
    }
}
