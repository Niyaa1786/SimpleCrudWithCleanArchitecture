using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Products
{
    public class GetAllProducts
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProducts(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<ProductDto>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var products = await _unitOfWork.Products.GetAllAsync(cancellationToken);

            return products.Select(p => ProductMapper.ToDto(p));
        }
    }
}
