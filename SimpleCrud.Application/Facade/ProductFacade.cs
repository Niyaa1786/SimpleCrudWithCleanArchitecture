using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.UseCases.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrud.Application.Facade
{
    public class ProductFacade : IProductFacade
    {
        private readonly CreateProduct _createProduct;
        private readonly UpdateProduct _updateProduct;
        private readonly DeleteProduct _deleteProduct;
        private readonly GetAllProducts _getAllProduct;
        private readonly GetAllProductsByCategory _getAllProductsByCategory;
        private readonly GetProductById _getProductById;

        public ProductFacade(
            CreateProduct createProduct,
            UpdateProduct updateProduct,
            DeleteProduct deleteProduct,
            GetAllProducts getAllProducts,
            GetAllProductsByCategory getAllProductsByCategory,
            GetProductById getProductById)
        {
            _createProduct = createProduct;
            _updateProduct = updateProduct;
            _deleteProduct = deleteProduct;
            _getAllProduct = getAllProducts;
            _getAllProductsByCategory = getAllProductsByCategory;
            _getProductById = getProductById;
        }

        public Task<ProductDto> CreateAsync(CreateProductRequest request,CancellationToken ct)
        {
            return _createProduct.ExecuteAsync(request, ct);
        }

        public Task<ProductDto> UpdateAsync(Guid id, UpdateProductRequest request, CancellationToken ct)
        {
            return _updateProduct.ExecuteAsync(id, request, ct);
        }

        public Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            return _deleteProduct.ExecuteAsync(id, ct);
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken ct)
        {
            return _getAllProduct.ExecuteAsync(ct);
        }

        public Task<IEnumerable<ProductDto>> GetAllByCategory(Guid id,CancellationToken ct)
        {
            return _getAllProductsByCategory.ExecuteAsync(id, ct);
        }

        public Task<ProductDto> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return _getProductById.ExecuteAsync(id, ct);
        }
    }
}
