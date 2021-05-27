using IntelviaStore.Models;
using IntelviaStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ICrudService<ProductModel>  _ProductService;

        public ProductController( ICrudService<ProductModel> ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet("GetProductModels")]
        public async Task<IActionResult> GetProductModels()
        {
            return Ok(await _ProductService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModels(int id)
        {
            return await _ProductService.Get(id);
        }

        [HttpPost("PostProductModels")]
        public async Task<ActionResult<ProductModel>> PostProductModels([FromBody] ProductModel ProductModel)
        {
            var newProductModel = await _ProductService.Create(ProductModel);
            return CreatedAtAction(nameof(GetProductModels), new { id = newProductModel.Id }, newProductModel);
        }

        [HttpPut("PutProductModels")]
        public async Task<ActionResult<ProductModel>> PutProductModels(int id, [FromBody] ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }
            await _ProductService.Update(productModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductModel>> DeleteProductModels(int id)
        {
            var productModelToDelete = await _ProductService.Get(id);
            if (productModelToDelete == null)
                return NotFound();

            await _ProductService.Delete(productModelToDelete.Id);
            return NoContent();
        }

                 
            
    }
}
