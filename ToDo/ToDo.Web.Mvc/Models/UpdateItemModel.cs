using System.ComponentModel.DataAnnotations;

namespace ToDo.Web.Mvc.Models
{

    public class UpdateItemModel : CreateItemModel
    {
        public UpdateItemModel()
        {

        }

        public UpdateItemModel(Guid guid, string description, bool done) : base(description, done)
        {
            this.Id = guid;
        }

        public Guid Id { get; set; }
    }
}
