using IntelviaStore.Models;
using IntelviaStore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICrudService<CategoryModel> _CategoryService;

        public CategoryController(ICrudService<CategoryModel> CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet("GetCategoryModels")]
        public async Task<IActionResult> GetCategoryModels()
        {
            return Ok(await _CategoryService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryModels(int id)
        {
            return await _CategoryService.Get(id);
        }

        [HttpPost("PostCategoryModels")]
        public async Task<ActionResult<CategoryModel>> PostCategoryModels([FromBody] CategoryModel CategoryModel)
        {
            var newCategoryModel = await _CategoryService.Create(CategoryModel);
            return CreatedAtAction(nameof(GetCategoryModels), new { id = newCategoryModel.Id }, newCategoryModel);
        }

        [HttpPut("PutCategoryModels")]
        public async Task<ActionResult<CategoryModel>> PutCategoryModels(int id, [FromBody] CategoryModel CategoryModel)
        {
            if (id != CategoryModel.Id)
            {
                return BadRequest();
            }
            await _CategoryService.Update(CategoryModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategoryModels(int id)
        {
            var CategoryModelToDelete = await _CategoryService.Get(id);
            if (CategoryModelToDelete == null)
                return NotFound();

            await _CategoryService.Delete(CategoryModelToDelete.Id);
            return NoContent();
        }

        }
}

