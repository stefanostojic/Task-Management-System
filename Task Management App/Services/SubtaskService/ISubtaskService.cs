using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Subtask;

namespace Task_Management_System.Services.SubtaskService
{
    public interface ISubtaskService : IGenericService<Subtask>
    {
        Task<Subtask> AddAsync(SubtaskPostDto entity);
        Task<bool> UpdateAsync(SubtaskPutDto entity);
    }
}
