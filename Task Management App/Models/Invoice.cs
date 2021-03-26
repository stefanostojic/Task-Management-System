using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Invoice
    {
        public Guid ID { get; set; }
        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
        public double Amount { get; set; }
        public bool Paid { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid UserID { get; set; }
    }
}
