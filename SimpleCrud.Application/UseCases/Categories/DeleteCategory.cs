using SimpleCrud.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Categories
{
    public class DeleteCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategory(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
            if (category == null) return false;

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return true;
        }
    }
}
