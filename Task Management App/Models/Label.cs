using System.Collections.Generic;

namespace Task_Management_System.Models
{
    public class Label : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<TaskLabel> TaskLabels { get; set; }
    }
}
