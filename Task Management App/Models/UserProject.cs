using System;

namespace Task_Management_System.Models
{
    public class UserProject
    {
        public bool Accepted { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        public Guid ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public Guid ProjectRoleID { get; set; }
        public virtual ProjectRole ProjectRole { get; set; }
    }
}
