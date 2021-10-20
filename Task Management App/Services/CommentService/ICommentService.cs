using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Comment;

namespace Task_Management_System.Services.CommentService
{
    public interface ICommentService : IGenericService<Comment>
    {
        Task<Comment> AddAsync(CommentPostDto entity);
        Task<bool> UpdateAsync(CommentPutDto entity);
    }
}
