using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.UserProjectService
{
    public interface IUserProjectService
    {
        Task<PagedResponse<UserProject>> GetAllAsync(PaginationFilter paginationFilter);
        Task<UserProject> GetByIdAsync(Guid userId, Guid projectId);
        Task<UserProject> AddAsync(UserProjectPostDto entity);
        Task<bool> UpdateAsync(UserProjectPutDto entity);
        Task<bool> RemoveAsync(UserProject entity);
        Task<bool> RemoveByIdAsync(Guid userId, Guid projectId);
    }
}
