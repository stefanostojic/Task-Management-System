using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Data;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.TaskGroupRepository
{
    public class TaskGroupRepository : GenericRepository<TaskGroup>, ITaskGroupRepository
    {
        public TaskGroupRepository(TaskManagementSystemContext taskManagementSystemContext, ILogger<TaskGroupRepository> logger)
            : base(taskManagementSystemContext, logger)
        {
        }

        public async Task<IEnumerable<TaskGroup>> GetByProjectIdAsync(PaginationFilter paginationQuery, Guid projectId)
        {
            _logger.LogInformation("GetByProjectIdAsync: ", projectId);

            return await _context.TaskGroups
                .Where(tg => tg.ProjectID == projectId)
                .ToListAsync();
        }
    }
}
