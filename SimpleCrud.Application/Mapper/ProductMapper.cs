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
    public static partial class ProductMapper
    {
        public static partial ProductDto ToDto(Product product);

        public static Product ToEntity(CreateProductRequest request)
        {
            return new Product(request.Name, request.Price, request.CategoryId);
        }

        public static void ApplyUpdates(UpdateProductRequest request,Product product)
        {
            product.Update(request.Name, request.Price, request.CategoryId);
        }
    }
}
