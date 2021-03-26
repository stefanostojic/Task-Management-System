using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Subtask
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Finished { get; set; }
        public Guid TaskID { get; set; }
    }
}
