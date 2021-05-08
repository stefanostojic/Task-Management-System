using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class ProPlanUser
    {
        public Guid UserID { get; set; }
        public Guid ProPlanID { get; set; }
        public DateTime StartDate { get; set; }
        public bool Active { get; set; }

        public virtual ProPlan ProPlan { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
