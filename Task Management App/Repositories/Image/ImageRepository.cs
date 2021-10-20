using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.ImageRepository
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }
    }
}
