using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class UserTask
    {
        public Guid ID { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public Guid UserID { get; set; }
        public Guid TaskID { get; set; }
        public Guid? TaskRoleID { get; set; }

        public User User { get; set; }
        public Task Task { get; set; }
        public TaskRole TaskRole { get; set; }
    }
}
