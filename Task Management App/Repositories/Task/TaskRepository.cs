using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_Management_System.Data;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.TaskRepository
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(TaskManagementSystemContext taskManagementSystemContext, ILogger<TaskRepository> logger)
            : base(taskManagementSystemContext, logger)
        {
        }

        public async System.Threading.Tasks.Task<PagedResponse<Task>> GetAllAsync(PaginationFilter paginationFilter, Guid taskGroupId)
        {
            var skip = paginationFilter.PageSize * (paginationFilter.PageNumber - 1);

            IQueryable<Task> tasksQuery = _context.Tasks;

            if (!taskGroupId.Equals(Guid.Empty))
            {
                tasksQuery = tasksQuery.Where(t => t.TaskGroupID.Equals(taskGroupId));
            }

            var pagedResponse = new PagedResponse<Task>();
            pagedResponse.CurrentPage = paginationFilter.PageNumber;
            pagedResponse.PageSize = paginationFilter.PageSize;

            pagedResponse.Items = await tasksQuery
                .Include(t => t.UserTasks)
                .ThenInclude(ut => ut.User)
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            pagedResponse.TotalItems = tasksQuery.Count();
            pagedResponse.TotalPages = pagedResponse.TotalItems / pageSize + 1;

            return pagedResponse;
        }
    }
}
