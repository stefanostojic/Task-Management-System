using System;

namespace Task_Management_System.Models.Dtos
{
    public class TaskGroupPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectID { get; set; }
    }
}
