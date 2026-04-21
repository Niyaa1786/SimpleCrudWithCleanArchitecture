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
        public CreateProduct(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ProductDto> ExecuteAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId, cancellationToken);
            if(category == null)
                throw new NotFoundException("Category not found.");

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
