namespace ToDo.Application.Dtos.Item
{
    public class ItemResponseDto : UpdateItemRequestDto
    {
        public ItemResponseDto()
        {

        }
        public ItemResponseDto(Guid id, string description, bool done, DateTime createdAt) : base(id, description, done)
        {
            this.CreatedAt = createdAt;
        }

        public DateTime CreatedAt { get; set; }
    }
}
