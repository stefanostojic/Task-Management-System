using System;

namespace Task_Management_System.Models.DTO.Contact
{
    public class ContactPutDto
    {
        public Guid User1ID { get; set; }
        public Guid User2ID { get; set; }
        public bool Accepted { get; set; }
    }
}
