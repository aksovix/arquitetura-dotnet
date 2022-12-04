using AutoMapper;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;

namespace ToDo.Application.AppServices
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemRepository repository;
        private readonly IMapper mapper;
        public ItemAppService(IItemRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddAsync(CreateItemRequestDto createItemRequestDto)
        {
            await repository.AddAsync(mapper.Map<Item>(createItemRequestDto));
        }

        public async Task<ItemResponseDto> GetAsync(Guid id)
        {
            var response = await repository.GetAsync(id);
            return mapper.Map<ItemResponseDto>(response);
        }

        public async Task<IEnumerable<ItemResponseDto>> GetAllAsync()
        {
            var response = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<ItemResponseDto>>(response);
        }

        public async Task UpdateAsync(UpdateItemRequestDto updateItemRequestDto)
        {
            await repository.UpdateAsync(mapper.Map<Item>(updateItemRequestDto));
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }
    }
}
