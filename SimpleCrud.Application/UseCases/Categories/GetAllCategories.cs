using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.Interfaces;
using SimpleCrud.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.UseCases.Categories
{
    public class GetAllCategories
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCategories(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<CategoryDto>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(cancellationToken);
            return categories.Select(c => CategoryMapper.ToDto(c));
        }
    }
}
