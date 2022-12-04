using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Infra.Data.Context;

namespace ToDo.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task AddAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            var entity = _context.Items.Attach(item);
            entity.Property(prop => prop.Id).IsModified = false;
            entity.Property(prop => prop.Description).IsModified = true;
            entity.Property(prop => prop.Done).IsModified = true;
            entity.Property(prop => prop.CreatedAt).IsModified = false;
            await _context.SaveChangesAsync();   
        }

        public async Task DeleteAsync(Guid Id)
        {
            _context.Items.Remove(GetAsync(Id).Result);
            await _context.SaveChangesAsync();
        }

    }
}
