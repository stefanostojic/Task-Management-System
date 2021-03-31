using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Contact
    {
        //public Guid ID { get; set; }
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }
        public bool Accepted { get; set; }

        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
