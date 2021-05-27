using IntelviaStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Services
{
    public class CategoryService : ICrudService<CategoryModel>
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryModel> Create(CategoryModel CategoryModel)
        {
            _context.CategoryModels.Add(CategoryModel);
            await _context.SaveChangesAsync();
            return CategoryModel;
        }


        public async Task<IEnumerable<CategoryModel>> Get()
        {
            return await _context.CategoryModels.ToListAsync();
        }

        public async Task<CategoryModel> Get(int Id)
        {
            return await _context.CategoryModels.FindAsync(Id);
        }

        public async Task Update(CategoryModel CategoryModel)
        {
            _context.Entry(CategoryModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var CategoryModelToDelete = await _context.CategoryModels.FindAsync(Id);
            _context.CategoryModels.Remove(CategoryModelToDelete);
            await _context.SaveChangesAsync();

        }


    }
}
    