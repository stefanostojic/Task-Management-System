﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class Label
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid TaskID { get; set; }
    }
}
