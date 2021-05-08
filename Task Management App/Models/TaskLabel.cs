using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class TaskLabel
    {
        public Guid TaskID { get; set; }
        public virtual Task Task { get; set; }
        public Guid LabelID { get; set; }
        public virtual Label Label { get; set; }
    }
}
