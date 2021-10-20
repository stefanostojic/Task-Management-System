using System;
using System.Collections.Generic;

namespace Task_Management_System.Models.Dtos
{
    public class TaskGroupWithTasksResponseDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskResponseDto> Tasks { get; set; }
    }
}
