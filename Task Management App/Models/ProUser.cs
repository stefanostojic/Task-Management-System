using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class ProUser : User
    {
        public DateTime StartDate { get; set; }
        public bool Active { get; set; }
        public Guid ProPlanID { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
