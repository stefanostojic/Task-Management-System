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
        public DateTime PostedOnDate { get; set; }
        public Guid UserID { get; set; }
        public Guid TaskID { get; set; }

        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
