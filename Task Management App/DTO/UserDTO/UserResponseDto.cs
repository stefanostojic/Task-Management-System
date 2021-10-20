using System;

namespace Task_Management_System.Models.Dtos
{
    public class UserResponseDto
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
    }
}
