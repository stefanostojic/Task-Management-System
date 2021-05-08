using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Models
{
    public class UserRole
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
