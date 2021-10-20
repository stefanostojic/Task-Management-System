using System;

namespace Task_Management_System.Models.DTO.Subtask
{
    public class SubtaskResponseDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Finished { get; set; }
        public Guid TaskID { get; set; }
    }
}
