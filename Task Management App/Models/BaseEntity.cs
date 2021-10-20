using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
    }
}
