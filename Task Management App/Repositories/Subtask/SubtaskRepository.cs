using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.SubtaskRepository
{
    public class SubtaskRepository : GenericRepository<Subtask>, ISubtaskRepository
    {
        public SubtaskRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }
    }
}
