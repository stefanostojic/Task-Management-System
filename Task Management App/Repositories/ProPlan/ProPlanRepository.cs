using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Task_Management_System.Data;
using Task_Management_System.Models;
using Task_Management_System.Repositories.ProjectRepository;

namespace Task_Management_System.Repositories.ProPlanRepository
{
    public class ProPlanRepository : GenericRepository<ProPlan>, IProPlanRepository
    {
        public ProPlanRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }

        public override async Task<ProPlan> GetByIdAsync(Guid id)
        {
            return await _context.ProPlans
                .Include(p => p.ProPlanUsers)
                .ThenInclude(pu => pu.User)
                .FirstOrDefaultAsync();
        }
    }
}
