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
            Id = Guid.NewGuid();
            Done = false;
            Description = task;
            CreatedAt = DateTime.Now;
        }
        public Item(string task, bool done)
        {
            Id = Guid.NewGuid();
            Done = done;
            Description = task;
            CreatedAt = DateTime.Now;
        }

        public Item(Guid Id, string task)
        {
            this.Id = Id;
            Description = task;
        }

        public Item(Guid Id, string task, bool done)
        {
            this.Id = Id;
            Description = task;
            Done = done;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
