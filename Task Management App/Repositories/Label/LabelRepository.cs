using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.LabelRepository
{
    public class LabelRepository : GenericRepository<Label>, ILabelRepository
    {
        public LabelRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }
    }
}
