using System;
using System.Collections.Generic;

namespace Task_Management_System.Models
{
    public class TaskGroup : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid ProjectID { get; set; }
        public virtual Project Project { get; set; }
        
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
