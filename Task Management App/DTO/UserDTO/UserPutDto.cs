using System;

namespace Task_Management_System.Models.Dtos
{
    public class UserPutDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
