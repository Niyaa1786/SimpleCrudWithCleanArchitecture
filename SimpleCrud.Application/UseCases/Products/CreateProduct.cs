using FluentValidation;
using FluentValidation.Results;
using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Exceptions;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Domain.Entities;


namespace SimpleCrud.Application.UseCases.Products
{
    public class CreateProduct
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateProductRequest> _validator;
        public CreateProduct(IUnitOfWork unitOfWork, IValidator<CreateProductRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ProductDto> ExecuteAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            _validator.ValidateAndThrow(request);
            var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId, cancellationToken);

            if(category == null)
            {
                var failure = new ValidationFailure(nameof(request.CategoryId), $"Category with Id {request.CategoryId} does not exist.");
                throw new ValidationException(new[] { failure });
            }

            var product = new Product(request.Name, request.Price, request.CategoryId);
            _unitOfWork.Products.Add(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = category.Name,
            };
        }
    }
}
