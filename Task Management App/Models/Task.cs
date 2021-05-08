using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Task
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public DateTime DueDate { get; set; }
        public Guid TaskGroupID { get; set; }

        public virtual TaskGroup TaskGroup { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
        public virtual ICollection<Subtask> Subtasks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<TaskLabel> TaskLabels { get; set; }
    }
}
