using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class UserImage : Image
    {
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
