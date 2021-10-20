using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;

namespace Task_Management_System.Repositories
{
    public interface IGenericRepository<T> where T : Models.BaseEntity
    {
        Task<PagedResponse<T>> GetAllAsync(PaginationFilter paginationFilter);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveByIdAsync(Guid id);
    }
}
