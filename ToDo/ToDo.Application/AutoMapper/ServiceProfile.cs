using AutoMapper;
using ToDo.Application.Dtos.Item;
using ToDo.Domain.Entities;

namespace ToDo.Application.AutoMapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Item, ItemResponseDto>();

            CreateMap<CreateItemRequestDto, Item>().
                ConvertUsing(dto => new Item(dto.Description, dto.Done));

            CreateMap<UpdateItemRequestDto, Item>().
                ConvertUsing(dto => new Item(dto.Id, dto.Description, dto.Done));
        }
    }
}
