using System;

namespace Task_Management_System.Models.DTO.Contact
{
    public class ContactResponseDto
    {
        public Guid User1ID { get; set; }
        public string User1FullName { get; set; }
        public Guid User2ID { get; set; }
        public string User2FullName { get; set; }
        public bool Accepted { get; set; }
    }
}
