using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<PagedResponse<User>> GetAllAsync(PaginationFilter paginationFilter);
        Task<User> GetByIdAsync(Guid id);
        Task<User> AddAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task<bool> RemoveAsync(User entity);
        Task<bool> RemoveByIdAsync(Guid id);
    }
}
