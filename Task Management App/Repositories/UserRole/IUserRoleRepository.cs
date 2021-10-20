using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.UserRoleRepository
{
    public interface IUserRoleRepository 
    {
        Task<PagedResponse<UserRole>> GetAllAsync(PaginationFilter paginationFilter);
        Task<UserRole> GetByIdAsync(Guid id);
        Task<UserRole> AddAsync(UserRole entity);
        Task<UserRole> UpdateAsync(UserRole entity);
        Task<bool> RemoveAsync(UserRole entity);
        Task<bool> RemoveByIdAsync(Guid id);
    }
}
