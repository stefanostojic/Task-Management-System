using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.UserTaskService
{
    public interface IUserTaskService
    {
        Task<PagedResponse<UserTask>> GetAllAsync(PaginationFilter paginationFilter);
        Task<UserTask> GetByIdAsync(Guid userId, Guid projectId);
        Task<UserTask> AddAsync(UserTaskPostDto entity);
        Task<bool> UpdateAsync(UserTaskPutDto entity);
        Task<bool> RemoveAsync(UserTask entity);
        Task<bool> RemoveByIdAsync(Guid userId, Guid projectId);
    }
}
