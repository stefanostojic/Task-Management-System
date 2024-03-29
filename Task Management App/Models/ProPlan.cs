﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class ProPlan : BaseEntity
    {
        //public Guid ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ProPlanUser> ProPlanUsers { get; set; }
    }
}
