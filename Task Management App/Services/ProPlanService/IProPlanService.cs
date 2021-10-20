using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.ProPlanService
{
    public interface IProPlanService : IGenericService<ProPlan>
    {
        Task<ProPlan> AddAsync(ProPlanPostDto entity);
        Task<bool> UpdateAsync(ProPlanPutDto entity);
    }
}
