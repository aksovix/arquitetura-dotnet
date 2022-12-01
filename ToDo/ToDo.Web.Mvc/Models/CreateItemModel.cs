
using System.ComponentModel.DataAnnotations;

namespace ToDo.Web.Mvc.Models
{
    public class CreateItemModel
    {
        public CreateItemModel()
        {

        }

        public CreateItemModel(string description, bool done)
        {
            Description = description;
            Done = done;
        }

        [StringLength(256, MinimumLength = 5)]
        public string Description { get; set; }

        public bool Done { get; set; }
    }
}
