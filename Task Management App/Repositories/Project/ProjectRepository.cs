using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Management_System.Data;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.ProjectRepository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }

        public override async Task<PagedResponse<Project>> GetAllAsync(PaginationFilter paginationFilter)
        {
            var skip = paginationFilter.PageSize * (paginationFilter.PageNumber - 1);
            var pagedResponse = new PagedResponse<Project>();
            pagedResponse.CurrentPage = paginationFilter.PageNumber;
            pagedResponse.PageSize = paginationFilter.PageSize;
            
            pagedResponse.Items = await _context.Set<Project>()
                .Include(p => p.User)
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            pagedResponse.TotalItems = _context.Set<Project>().Count();
            pagedResponse.TotalPages = pagedResponse.TotalItems / pageSize + 1;

            return pagedResponse;
        }
    }
}
