using Riok.Mapperly.Abstractions;
using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Mapper
{
    [Mapper]
    public static partial class CategoryMapper
    {
        [MapProperty(nameof(Category.Products.Count),nameof(CategoryDto.ProductCount))]
        public static partial CategoryDto ToDto(Category category);

        public static Category ToEntity(CreateCategoryRequest request)
        {
            return new Category(request.Name);
        }

        public static void ApplyUpdates(UpdateCategoryRequest request, Category category)
        {
            category.Update(request.Name);
        }
    }
}
