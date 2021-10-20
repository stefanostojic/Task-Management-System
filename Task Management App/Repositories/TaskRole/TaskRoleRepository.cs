using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.Repositories.ProjectRepository;

namespace Task_Management_System.Repositories.TaskRoleRepository
{
    public class TaskRoleRepository : GenericRepository<TaskRole>, ITaskRoleRepository
    {
        public TaskRoleRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }
    }
}
