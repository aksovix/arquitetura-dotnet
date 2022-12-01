using System.Security.AccessControl;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Infra.Data.Repositories;
using ToDo.Web.Mvc.Models;

namespace ToDo.Web.Mvc.Extensions
{
    public static class MapperExtension
    {
        public static Item ConvertToItem(this CreateItemModel CreateItemModel)
        {
            return new Item(CreateItemModel.Description, CreateItemModel.Done);
        }
        public static Item ConvertToItem(this UpdateItemModel UpdateItemModel)
        {
            return new Item(UpdateItemModel.Id, UpdateItemModel.Description, UpdateItemModel.Done);
        }
        public static CreateItemModel ConvertToCreateItemModel(this Item item)
        {
            return new CreateItemModel(item.Description, item.Done);
        }
        public static UpdateItemModel ConvertToUpdateItemModel(this Item item)
        {
            return new UpdateItemModel(item.Id, item.Description, item.Done);
        }
    }
}
