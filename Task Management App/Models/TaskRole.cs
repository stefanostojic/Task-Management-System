using System;
using System.Collections.Generic;

namespace Task_Management_System.Models
{
    public class TaskRole : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
