using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Products
{
    public class GetAllProductsByCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProductsByCategory(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<ProductDto>> ExecuteAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            var products = await _unitOfWork.Products.GetAllByCategoryAsync(categoryId, cancellationToken);
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name ?? string.Empty,
            });
        }
    }
}
