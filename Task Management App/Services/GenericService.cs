using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Repositories;

namespace Task_Management_System.Services
{
    public class GenericService<T> : IGenericService<T> where T : Models.BaseEntity
    {
        protected IGenericRepository<T> _repository;
        protected ILogger<GenericService<T>> _logger;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public GenericService(IGenericRepository<T> repository, ILogger<GenericService<T>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PagedResponse<T>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await _repository.GetAllAsync(paginationFilter);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var exists = await _repository.GetByIdAsync(entity.ID);
            if (exists == null)
                return false;
            else
            {
                await _repository.UpdateAsync(entity);
                return true;
            }
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            var exists = _repository.GetByIdAsync(entity.ID);
            if (exists == null)
            {
                return false;
            }
            else
            {
                await _repository.RemoveAsync(entity);
                return true;
            }
        }

        public async Task<bool> RemoveByIdAsync(Guid id)
        {
            var entityToRemove = await _repository.GetByIdAsync(id);
            if (entityToRemove == null)
            {
                return false;
            }
            else
            {
                await _repository.RemoveAsync(entityToRemove);
                return true;
            }
        }
    }
}
