using System;

namespace Task_Management_System.Models
{
    public class UserTask
    {
        public DateTime AssignmentDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        public Guid TaskID { get; set; }
        public virtual Task Task { get; set; }
        public Guid? TaskRoleID { get; set; }
        public virtual TaskRole TaskRole { get; set; }
    }
}
