using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Api.Responses;
using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Facade;
using SimpleCrud.Application.UseCases.Categories;
using SimpleCrud.Application.UseCases.Products;
using SimpleCrud.Domain.Entities;

namespace SimpleCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductFacade _productFacade;
        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var products = await _productFacade.GetAllAsync(ct);
            var res = ApiResponse<IEnumerable<ProductDto>>.Ok(products);
            return Ok(res);
        }
        [HttpGet("by-category/{id}")]
        public async Task<IActionResult> GetAllByCategory(Guid id,CancellationToken ct)
        {
            var products = await _productFacade.GetAllByCategory(id, ct);
            var res = ApiResponse<IEnumerable<ProductDto>>.Ok(products);
            return Ok(res);
        }

        [HttpGet("{id:guid}/details")]
        public async Task<IActionResult> GetById(Guid id,CancellationToken ct)
        {
            var products = await _productFacade.GetByIdAsync(id, ct);
            var res = ApiResponse<ProductDto>.Ok(products);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request,CancellationToken ct)
        {
            var newProduct = await _productFacade.CreateAsync(request, ct);
            var res = ApiResponse<ProductDto>.Ok(newProduct, "Create Successfully");
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, res);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request,CancellationToken ct)
        {
            var updatedProduct = await _productFacade.UpdateAsync(id,request,ct);
            var res = ApiResponse<ProductDto>.Ok(updatedProduct, "Update Successfully");
            return Ok(updatedProduct);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var result = await _productFacade.DeleteAsync(id, ct);
            if (result is false)
            {
                var errorResponse = ApiResponse<object>.Error("Product Not Found");
                return NotFound();
            }
            var res = ApiResponse<object>.Ok(null, "Delete Successfully");
            return NoContent();
        }
    }
}
