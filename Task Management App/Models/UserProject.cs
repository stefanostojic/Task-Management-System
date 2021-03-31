using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class UserProject
    {
        //public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
