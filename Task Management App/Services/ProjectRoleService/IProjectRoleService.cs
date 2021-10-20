using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.ProjectRole;

namespace Task_Management_System.Services.ProjectRoleService
{
    public interface IProjectRoleService : IGenericService<ProjectRole>
    {
        Task<ProjectRole> AddAsync(ProjectRolePostDto entity);
        Task<bool> UpdateAsync(ProjectRolePutDto entity);
    }
}
