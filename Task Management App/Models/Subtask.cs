using System;

namespace Task_Management_System.Models
{
    public class Subtask : BaseEntity
    {
        public string Name { get; set; }
        public bool Finished { get; set; }

        public Guid TaskID { get; set; }
        public virtual Task Task { get; set; }
    }
}
