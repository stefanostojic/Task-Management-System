using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.UserService
{
    public interface IUserService
    {
        Task<PagedResponse<User>> GetAllAsync(PaginationFilter paginationFilter);
        Task<User> GetByIdAsync(Guid id);
        Task<User> AddAsync(UserPostDto entity);
        Task<bool> UpdateAsync(UserPutDto entity);
        Task<bool> RemoveAsync(User entity);
        Task<bool> RemoveByIdAsync(Guid id);
    }
}
