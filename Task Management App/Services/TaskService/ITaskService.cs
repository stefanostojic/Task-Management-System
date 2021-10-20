using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.TaskService
{
    public interface ITaskService : IGenericService<Models.Task>
    {
        Task<PagedResponse<Models.Task>> GetAllAsync(PaginationFilter paginationFilter, Guid taskGroupId);
        Task<Models.Task> AddAsync(TaskPostDto entity);
        Task<bool> UpdateAsync(TaskPutDto entity);
    }
}
