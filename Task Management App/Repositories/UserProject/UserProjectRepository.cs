using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Data;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.UserProjectRepository
{
    public class UserProjectRepository : IUserProjectRepository
    {
        protected readonly TaskManagementSystemContext _context;
        protected readonly int pageSize = 3;

        public UserProjectRepository(TaskManagementSystemContext taskManagementSystemContext)
        {
            _context = taskManagementSystemContext;
        }

        public virtual async Task<PagedResponse<UserProject>> GetAllAsync(PaginationFilter paginationFilter)
        {
            var skip = paginationFilter.PageSize * (paginationFilter.PageNumber - 1);
            var pagedResponse = new PagedResponse<UserProject>();
            pagedResponse.CurrentPage = paginationFilter.PageNumber;
            pagedResponse.PageSize = paginationFilter.PageSize;

            pagedResponse.Items = await _context.Set<UserProject>()
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            pagedResponse.TotalItems = _context.Set<UserProject>().Count();
            pagedResponse.TotalPages = pagedResponse.TotalItems / pageSize + 1;

            return pagedResponse;
        }

        public virtual async Task<UserProject> GetByIdAsync(Guid userId, Guid projectId)
        {
            return await _context.Set<UserProject>()
                .FindAsync(userId, projectId);
        }

        public virtual async Task<UserProject> AddAsync(UserProject entity)
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

        public virtual async Task<UserProject> UpdateAsync(UserProject entity)
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

        public virtual async Task<bool> RemoveAsync(UserProject entity)
        {
            if (await _context.Set<UserProject>().FindAsync() == null)
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

        public virtual async Task<bool> RemoveByIdAsync(Guid userId, Guid projectId)
        {
            if (await _context.Set<UserProject>().FindAsync() == null)
            {
                throw new ArgumentException($"{nameof(UserProject)} could not be found");
            }

            try
            {
                var entityToRemove = await _context.Set<UserProject>()
                    .FindAsync(userId, projectId);

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
                throw new Exception($"{nameof(UserProject)} could not be updated: {ex.Message}");
            }

        }
    }
}
