using System;

namespace Task_Management_System.Models.Dtos
{
    public class UserTaskPutDto
    {
        public DateTime EstimatedEndDate { get; set; }
        public Guid UserID { get; set; }
        public Guid TaskID { get; set; }
        public Guid? TaskRoleID { get; set; }
    }
}
