using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Block
    {
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }
        public DateTime Date { get; set; }

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
