using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Exceptions;
using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Products
{
    public class UpdateProduct
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProduct(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ProductDto> ExecuteAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
            if(product == null) throw new NotFoundException($"Product with id {id} not found.");

            product.Update(request.Name, request.Price, request.CategoryId);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }
    }
}
