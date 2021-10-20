using Task_Management_System.Data;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(TaskManagementSystemContext taskManagementSystemContext)
            : base(taskManagementSystemContext)
        {
        }
    }
}
