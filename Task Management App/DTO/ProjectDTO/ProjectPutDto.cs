using System;

namespace Task_Management_System.Models.Dtos
{
    public class ProjectPutDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
    }
}
