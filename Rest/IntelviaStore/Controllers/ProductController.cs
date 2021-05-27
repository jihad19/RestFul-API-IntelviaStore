using IntelviaStore.Models;
using IntelviaStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IAuthService _authService;

        public ProductController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("GetProductModels")]
        public async Task<IEnumerable<ProductModel>> GetProductModels()
        {
            return await _authService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModels(int id)
        {
            return await _authService.Get(id);
        }

        [HttpPost("PostProductModels")]
        public async Task<ActionResult<ProductModel>> PostProductModels([FromBody] ProductModel ProductModel)
        {
            var newProductModel = await _authService.Create(ProductModel);
            return CreatedAtAction(nameof(GetProductModels), new { id = newProductModel.Id }, newProductModel);
        }

        [HttpPut("PutProductModels")]
        public async Task<ActionResult<ProductModel>> PutProductModels(int id, [FromBody] ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }
            await _authService.Update(productModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductModel>> DeleteProductModels(int id)
        {
            var productModelToDelete = await _authService.Get(id);
            if (productModelToDelete == null)
                return NotFound();

            await _authService.Delete(productModelToDelete.Id);
            return NoContent();


        }


    }
}
