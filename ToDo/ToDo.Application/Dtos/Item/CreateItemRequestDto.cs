using System.ComponentModel.DataAnnotations;

namespace ToDo.Application.Dtos.Item
{
    public class CreateItemRequestDto
    {
        public CreateItemRequestDto()
        {

        }

        public CreateItemRequestDto(string description, bool done)
        {
            Description = description;
            Done = done;
        }

        [Required]
        [StringLength(256, MinimumLength = 5)]
        public string Description { get; set; }

        public bool Done { get; set; }
    }
}
