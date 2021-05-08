using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class UserProject
    {
        public Guid UserID { get; set; }
        public Guid ProjectID { get; set; }
        public bool Accepted { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectRole ProjectRole { get; set; }
    }
}
