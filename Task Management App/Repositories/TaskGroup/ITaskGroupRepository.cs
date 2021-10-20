using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.TaskGroupRepository
{
    public interface ITaskGroupRepository : IGenericRepository<TaskGroup>
    {
        Task<IEnumerable<TaskGroup>> GetByProjectIdAsync(PaginationFilter paginationQuery, Guid projectId);
    }
}
