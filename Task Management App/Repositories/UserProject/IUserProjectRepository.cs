using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.UserProjectRepository
{
    public interface IUserProjectRepository
    {
        Task<PagedResponse<UserProject>> GetAllAsync(PaginationFilter paginationFilter);
        Task<UserProject> GetByIdAsync(Guid userId, Guid projectId);
        Task<UserProject> AddAsync(UserProject entity);
        Task<UserProject> UpdateAsync(UserProject entity);
        Task<bool> RemoveAsync(UserProject entity);
        Task<bool> RemoveByIdAsync(Guid userId, Guid projectId);
    }
}
