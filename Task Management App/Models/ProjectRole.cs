using System;
using System.Collections.Generic;

namespace Task_Management_System.Models
{
    public class ProjectRole
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
