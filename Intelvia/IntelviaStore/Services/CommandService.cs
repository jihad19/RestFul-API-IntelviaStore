using IntelviaStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Services
{
    public class CommandService: ICrudService<CommandModal>
    {
        private readonly ApplicationDbContext _context;
        public CommandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommandModal> Create(CommandModal CommandModal)
        {
            _context.CommandModals.Add(CommandModal);
            await _context.SaveChangesAsync();
            return CommandModal;
        }


        public async Task<IEnumerable<CommandModal>> Get()
        {
            return await _context.CommandModals.ToListAsync();
        }

        public async Task<CommandModal> Get(int Id)
        {
            return await _context.CommandModals.FindAsync(Id);
        }

        public async Task Update(CommandModal CommandModal)
        {
            _context.Entry(CommandModal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var CommandModalToDelete = await _context.CategoryModels.FindAsync(Id);
            _context.CategoryModels.Remove(CommandModalToDelete);
            await _context.SaveChangesAsync();

        }

    }
}
