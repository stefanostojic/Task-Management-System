using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.Data;
using Task_Management_System.Models;
using System.Linq;
using Microsoft.Extensions.Logging;
using Task_Management_System.DTO;

namespace Task_Management_System.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly TaskManagementSystemContext _context;
        protected readonly int pageSize = 3;
        protected readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(TaskManagementSystemContext taskManagementSystemContext)
        {
            _context = taskManagementSystemContext;
        }

        public GenericRepository(TaskManagementSystemContext taskManagementSystemContext, ILogger<GenericRepository<T>> logger)
        {
            _context = taskManagementSystemContext;
            _logger = logger;
        }

        public virtual async Task<PagedResponse<T>> GetAllAsync(PaginationFilter paginationFilter)
        {
            var skip = paginationFilter.PageSize * (paginationFilter.PageNumber - 1);
            var pagedResponse = new PagedResponse<T>();
            pagedResponse.CurrentPage = paginationFilter.PageNumber;
            pagedResponse.PageSize = paginationFilter.PageSize;

            pagedResponse.Items = await _context.Set<T>()
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            pagedResponse.TotalItems = _context.Set<T>().Count();
            pagedResponse.TotalPages = pagedResponse.TotalItems / pageSize + 1;

            return pagedResponse;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new NotFoundException();
            }

            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }

        }

        public virtual async Task<bool> RemoveAsync(T entity)
        {
            if (await GetByIdAsync(entity.ID) == null)
            {
                throw new ArgumentException($"{nameof(entity)} could not be found");
            }

            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public virtual async Task<bool> RemoveByIdAsync(Guid id)
        {
            if (await _context.Set<T>().FindAsync() == null)
            {
                throw new ArgumentException($"{nameof(T)} could not be found");
            }

            try
            {
                var entityToRemove = await _context.Set<T>().FindAsync(id);
                if (entityToRemove != null)
                {
                    _context.Remove(entityToRemove);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(T)} could not be updated: {ex.Message}");
            }

        }
    }
}
