using FluentValidation;
using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Exceptions;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Products
{
    public class UpdateProduct
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateProductRequest> _validator;
        public UpdateProduct(IUnitOfWork unitOfWork, IValidator<UpdateProductRequest> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ProductDto> ExecuteAsync(Guid id, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
            if(product == null) throw new NotFoundException($"Product with id {id} not found.");

            var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryId, cancellationToken);
            if (category == null) throw new NotFoundException($"Category with id {request!.CategoryId} not found.");

            ProductMapper.ApplyUpdates(request, product);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ProductMapper.ToDto(product);
        }
    }
}
