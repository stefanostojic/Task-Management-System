using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.UserTaskRepository
{
    public interface IUserTaskRepository
    {
        Task<PagedResponse<UserTask>> GetAllAsync(PaginationFilter paginationFilter);
        Task<UserTask> GetByIdAsync(Guid userId, Guid projectId);
        Task<UserTask> AddAsync(UserTask entity);
        Task<UserTask> UpdateAsync(UserTask entity);
        Task<bool> RemoveAsync(UserTask entity);
        Task<bool> RemoveByIdAsync(Guid userId, Guid projectId);
    }
}
