using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using ToDo.Domain.Extensions;

namespace ToDo.Domain.Entities
{
    public class Item
    {
        /// <summary>
        /// Put it after
        /// </summary>
        private Item()
        {

        }

        public Item(string task)
        {
            Done = false;
            Description = task;
            CreatedAt = DateTime.Now;
        }

        public Item(string task, bool done)
        {
            Done = done;
            Description = task;
            CreatedAt = DateTime.Now;
        }

        public Item(Guid id, string task, bool done)
        {
            Id = id;
            Description = task;
            Done = done;
            CreatedAt = DateTime.Now;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
