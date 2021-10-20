using System;

namespace Task_Management_System.Models.Dtos
{
    public class ProPlanResponseDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
    }
}
