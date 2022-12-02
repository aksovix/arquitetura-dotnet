using ToDo.Application.Dtos.Item;

namespace ToDo.Application.Interfaces
{
    public interface IItemAppService
    {
        Task AddAsync(CreateItemRequestDto dto);
        Task<ItemResponseDto> GetAsync(Guid id);
        Task<IEnumerable<ItemResponseDto>> GetAllAsync();
        Task UpdateAsync(UpdateItemRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
