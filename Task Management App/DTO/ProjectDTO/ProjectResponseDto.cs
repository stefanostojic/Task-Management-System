using System;

namespace Task_Management_System.Models.Dtos
{
    public class ProjectResponseDto
    {
        public Guid ID { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserFullName { get; set; }
    }
}
