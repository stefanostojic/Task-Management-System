using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Project
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //[JsonIgnore]
        public Guid UserID { get; set; }

        //[JsonIgnore]
        public virtual User User { get; set; }
        public virtual ICollection<TaskGroup> TaskGroups { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
