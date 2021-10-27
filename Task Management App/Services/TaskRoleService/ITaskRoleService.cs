using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.TaskRoleService
{
    public interface ITaskRoleService : IGenericService<TaskRole>
    {
        Task<TaskRole> AddAsync(TaskRolePostDto entity);
        Task<bool> UpdateAsync(TaskRolePutDto entity);
    }
}
