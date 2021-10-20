using System;

namespace Task_Management_System.Models.DTO.Block
{
    public class BlockPutDto
    {
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }
        public DateTime Date { get; set; }
    }
}
