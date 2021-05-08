using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Image //dd
    {
        public Guid ID { get; set; }
        public string FilePath { get; set; }

        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Task Task { get; set; }
    }
}
