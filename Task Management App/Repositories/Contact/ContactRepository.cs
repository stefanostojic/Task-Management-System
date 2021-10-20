using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Data;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        protected readonly TaskManagementSystemContext _context;
        protected readonly int pageSize = 3;

        public ContactRepository(TaskManagementSystemContext taskManagementSystemContext)
        {
            _context = taskManagementSystemContext;
        }

        public virtual async Task<PagedResponse<Contact>> GetAllAsync(PaginationFilter paginationFilter)
        {
            var skip = paginationFilter.PageSize * (paginationFilter.PageNumber - 1);
            var pagedResponse = new PagedResponse<Contact>();
            pagedResponse.CurrentPage = paginationFilter.PageNumber;
            pagedResponse.PageSize = paginationFilter.PageSize;

            pagedResponse.Items = await _context.Set<Contact>()
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();

            pagedResponse.TotalItems = _context.Set<Contact>().Count();
            pagedResponse.TotalPages = pagedResponse.TotalItems / pageSize + 1;

            return pagedResponse;
        }

        public virtual async Task<Contact> GetByIdAsync(Guid user1Id, Guid user2Id)
        {
            return await _context.Set<Contact>().FindAsync(user1Id, user2Id);
            //throw new NotImplementedException();
        }

        public virtual async Task<Contact> AddAsync(Contact entity)
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

        public virtual async Task<Contact> UpdateAsync(Contact entity)
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

        public virtual async Task<bool> RemoveAsync(Contact entity)
        {
            if (await _context.Set<Contact>().FindAsync() == null)
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

        public virtual async Task<bool> RemoveByIdAsync(Guid user1Id, Guid user2Id)
        {
            if (await _context.Set<Contact>().FindAsync() == null)
            {
                throw new ArgumentException($"{nameof(Contact)} could not be found");
            }

            try
            {
                var entityToRemove = await _context.Set<Contact>().FindAsync(user1Id, user2Id);
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
                throw new Exception($"{nameof(Contact)} could not be updated: {ex.Message}");
            }

        }
    }
}
