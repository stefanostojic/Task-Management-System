using System;
using System.Collections.Generic;

namespace Task_Management_System.Models.Dtos
{
    public class TaskResponseDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public DateTime DueDate { get; set; }
        public Guid TaskGroupID { get; set; }
        public List<UserResponseDto> Assignees { get; set; }
    }
}
