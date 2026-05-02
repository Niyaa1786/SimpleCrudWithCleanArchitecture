using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Facade;

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
            return Ok(await _productFacade.GetAllAsync(ct));
        }
        [HttpGet("by-category/{id}")]
        public async Task<IActionResult> GetAllByCategory(Guid id,CancellationToken ct)
        {
            return Ok(await _productFacade.GetAllByCategory(id, ct));
        }

        [HttpGet("{id:guid}/details")]
        public async Task<IActionResult> GetById(Guid id,CancellationToken ct)
        {
            return Ok(await _productFacade.GetByIdAsync(id, ct));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request,CancellationToken ct)
        {
            var newProduct = await _productFacade.CreateAsync(request, ct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id },newProduct);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request,CancellationToken ct)
        {
            var updatedProduct = await _productFacade.UpdateAsync(id,request,ct);
            return Ok(updatedProduct);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var result = await _productFacade.DeleteAsync(id, ct);
            if (result is false)
                return NotFound();
            return NoContent();
        }
    }
}
