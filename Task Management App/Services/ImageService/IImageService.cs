using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Image;

namespace Task_Management_System.Services.ImageService
{
    public interface IImageService : IGenericService<Image>
    {
        Task<Image> AddAsync(ImagePostDto entity);
        Task<bool> UpdateAsync(ImagePutDto entity);
    }
}
