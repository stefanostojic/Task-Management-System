using System;

namespace Task_Management_System.Models.DTO.Block
{
    public class BlockResponseDto
    {
        public Guid User1ID { get; set; }
        public string User1FullName { get; set; }
        public Guid User2ID { get; set; }
        public string User2FullName { get; set; }
        public DateTime Date { get; set; }
    }
}
