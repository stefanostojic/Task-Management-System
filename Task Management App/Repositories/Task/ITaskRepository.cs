using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;

namespace Task_Management_System.Repositories.TaskRepository
{
    public interface ITaskRepository : IGenericRepository<Models.Task>
    {
        Task<PagedResponse<Models.Task>> GetAllAsync(PaginationFilter paginationFilter, Guid taskGroupId);
    }
}
