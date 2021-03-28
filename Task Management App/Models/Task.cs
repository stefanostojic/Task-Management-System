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
        //public Guid TaskGroupID { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
        public List<Subtask> Subtasks { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Image> Images { get; set; }
    }
}
