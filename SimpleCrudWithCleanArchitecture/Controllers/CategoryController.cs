using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Api.Responses;
using SimpleCrud.Application.DTOs;
using SimpleCrud.Application.DTOs.Request;
using SimpleCrud.Application.Facade;

namespace SimpleCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryFacade _categoryFacade;
        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {   
            var categories = await _categoryFacade.GetAllAsync(ct);
            var res = ApiResponse<IEnumerable<CategoryDto>>.Ok(categories);
            return Ok(res);
        }

        [HttpGet("{id:guid}/detail")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var category = await _categoryFacade.GetByIdAsync(id,ct);
            var res = ApiResponse<CategoryDto>.Ok(category);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request, CancellationToken ct)
        {
            var reqCategory = await _categoryFacade.CreateAsync(request,ct);
            var res = ApiResponse<CategoryDto>.Ok(reqCategory, "Create Successfully");
            return CreatedAtAction(nameof(GetById), new { id = reqCategory.Id }, res);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryRequest request, CancellationToken ct)
        {
            var updatedCategory = await _categoryFacade.UpdateAsync(id,request,ct);
            var res = ApiResponse<CategoryDto>.Ok(updatedCategory, "Update Successfully");
            return Ok(res);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var result = await _categoryFacade.DeleteAsync(id, ct);
            if (result is false)
            {
                var errorResponse = ApiResponse<object>.Error("Product Not Found");
                return NotFound(errorResponse);
            }
            var res = ApiResponse<object>.Ok(null, "Delete Successfully");
            return Ok(res);
        }
    }
}
