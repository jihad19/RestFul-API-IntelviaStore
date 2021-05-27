using IntelviaStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Services
{
    public class ProductService : ICrudService<ProductModel>
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        { 
            _context = context;
        }

        public async Task<ProductModel> Create(ProductModel productModel)
        {
            _context.ProductModels.Add(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }


        public async Task<IEnumerable<ProductModel>> Get()
        {
            return await _context.ProductModels.ToListAsync();
        }

        public async Task<ProductModel> Get(int Id)
        {
            return await _context.ProductModels.FindAsync(Id);
        }

        public async Task Update(ProductModel productModel)
        {
            _context.Entry(productModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var productModelToDelete = await _context.ProductModels.FindAsync(Id);
            _context.ProductModels.Remove(productModelToDelete);
            await _context.SaveChangesAsync();

        }

        
    }
}
