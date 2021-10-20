using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.TaskGroupService
{
    public interface ITaskGroupService
    {
        Task<PagedResponse<TaskGroup>> GetAllAsync(PaginationFilter paginationFilter);
        Task<TaskGroup> GetByIdAsync(Guid id);
        Task<TaskGroup> AddAsync(TaskGroupPostDto entity);
        Task<bool> UpdateAsync(TaskGroupPutDto entity);
        Task<bool> RemoveAsync(TaskGroup entity);
        Task<bool> RemoveByIdAsync(Guid id);

        Task<IEnumerable<TaskGroup>> GetByProjectIdAsync(PaginationFilter paginationQuery, Guid projectId);
    }
}
