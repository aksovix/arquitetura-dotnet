using System.ComponentModel.DataAnnotations;

namespace ToDo.Application.Dtos.Item
{
    public class UpdateItemRequestDto : CreateItemRequestDto
    {
        public UpdateItemRequestDto()
        {

        }

        public UpdateItemRequestDto(Guid guid, string description, bool done) : base(description, done)
        {
            this.Id = guid;
        }

        public Guid Id { get; set; }
    }
}
