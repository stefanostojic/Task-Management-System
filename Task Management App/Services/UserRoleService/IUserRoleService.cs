using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.UserRole;

namespace Task_Management_System.Services.UserRoleService
{
    public interface IUserRoleService
    {
        Task<PagedResponse<UserRole>> GetAllAsync(PaginationFilter paginationFilter);
        Task<UserRole> GetByIdAsync(Guid id);
        Task<UserRole> AddAsync(UserRolePostDto entity);
        Task<bool> UpdateAsync(UserRolePutDto entity);
        Task<bool> RemoveAsync(UserRole entity);
        Task<bool> RemoveByIdAsync(Guid id);
    }
}
