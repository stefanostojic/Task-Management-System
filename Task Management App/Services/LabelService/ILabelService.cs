using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Label;

namespace Task_Management_System.Services.LabelService
{
    public interface ILabelService : IGenericService<Label>
    {
        Task<Label> AddAsync(LabelPostDto entity);
        Task<bool> UpdateAsync(LabelPutDto entity);
    }
}
