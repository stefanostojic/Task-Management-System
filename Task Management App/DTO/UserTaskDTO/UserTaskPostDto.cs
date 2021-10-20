using System;

namespace Task_Management_System.Models.Dtos
{
    public class UserTaskPostDto
    {
        public DateTime EstimatedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public Guid UserID { get; set; }
        public Guid TaskID { get; set; }
        public Guid? TaskRoleID { get; set; }
    }
}
