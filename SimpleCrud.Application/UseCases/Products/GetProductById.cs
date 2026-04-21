using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.Exceptions;
using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Products
{
    public class GetProductById
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductById(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ProductDto> ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
            if (product == null) throw new NotFoundException($"Product with id {id} not found.");
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? string.Empty,
            };
        }
    }
}
