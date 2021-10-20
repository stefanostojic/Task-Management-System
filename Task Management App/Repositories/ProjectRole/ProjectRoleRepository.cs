using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.ProjectRoleRepository
{
    public class ProjectRoleRepository : GenericRepository<ProjectRole>, IProjectRoleRepository
    {
        public ProjectRoleRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }
    }
}
