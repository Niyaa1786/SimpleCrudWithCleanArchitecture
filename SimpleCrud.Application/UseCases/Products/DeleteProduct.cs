using SimpleCrud.Application.Exceptions;
using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Products
{
    public class DeleteProduct
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProduct(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
        {
             var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);
            if (product == null) return false;

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return true;
        }
    }
}
