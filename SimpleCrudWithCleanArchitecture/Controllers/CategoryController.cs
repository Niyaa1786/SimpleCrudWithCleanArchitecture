using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(categories);
        }

        [HttpGet("{id:guid}/detail")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var category = await _categoryFacade.GetByIdAsync(id,ct);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request, CancellationToken ct)
        {
            var reqCategory = await _categoryFacade.CreateAsync(request,ct);
            return CreatedAtAction(nameof(GetById), new { id = reqCategory.Id }, reqCategory);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryRequest request, CancellationToken ct)
        {
            var updatedCategory = await _categoryFacade.UpdateAsync(id,request,ct);
            return Ok(updatedCategory);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var result = await _categoryFacade.DeleteAsync(id, ct);
            if (result is false)
                return NotFound();
            return NoContent();
        }
    }
}
