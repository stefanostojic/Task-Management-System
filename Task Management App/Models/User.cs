using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Task_Management_System.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ProPlanUser ProPlanUser { get; set; }
        public Guid UserRoleID { get; set; }
        public virtual UserRole UserRole { get; set; }
        //public Guid? ImageID { get; set; }
        //public virtual Image Image { get; set; }

        public virtual ICollection<Contact> ContactsByUser { get; set; }
        public virtual ICollection<Contact> ContactsByOthers { get; set; }
        public virtual ICollection<Block> BlocksByUser { get; set; }
        public virtual ICollection<Block> BlocksByOthers { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<UserTask> UserTasks { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
