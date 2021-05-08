using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Data
{
    public interface IRepository<T> 
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}
