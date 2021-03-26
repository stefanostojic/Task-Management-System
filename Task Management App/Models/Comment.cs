using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Comment
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Guid UserID { get; set; }
        public Guid TaskID { get; set; }
    }
}
