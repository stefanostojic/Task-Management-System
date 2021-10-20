using System;

namespace Task_Management_System.Models.Dtos
{
    public class UserProjectResponseDto
    {
        public bool Accepted { get; set; }
        public Guid UserID { get; set; }
        public Guid ProjectID { get; set; }
        public Guid ProjectRoleID { get; set; }
    }
}
