using ToDo.Domain.Entities;

namespace ToDo.Domain.Interface
{
    public interface IItemRepository
    {
        Task AddAsync(Item item);
        Task<Item> GetAsync(Guid Id);
        Task<IEnumerable<Item>> GetAllAsync();
        Task UpdateAsync(Item item);
        Task DeleteAsync(Guid Id);
    }
}
