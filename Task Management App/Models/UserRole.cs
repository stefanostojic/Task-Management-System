using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Task_Management_System.Models
{
    public class UserRole : IdentityRole<Guid>
    {
        //public Guid ID { get; set; }
        //public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
