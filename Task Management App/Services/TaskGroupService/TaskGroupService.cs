using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories;
using Task_Management_System.Repositories.TaskGroupRepository;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.TaskGroupService
{
    public class TaskGroupService : ITaskGroupService
    {
        private readonly ITaskGroupRepository _repository;
        private readonly IMapper mapper;

        public TaskGroupService(ITaskGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<TaskGroup>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await _repository.GetAllAsync(paginationFilter);
        }

        public async Task<TaskGroup> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TaskGroup> AddAsync(TaskGroupPostDto entity)
        {
            TaskGroupPostDtoValidator validator = new TaskGroupPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("TaskGroupPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<TaskGroup>(entity));
        }

        public async Task<bool> UpdateAsync(TaskGroupPutDto entity)
        {
            var exists = await _repository.GetByIdAsync(entity.ID);
            if (exists == null)
                return false;
            else
            {
                await _repository.UpdateAsync(mapper.Map<TaskGroup>(entity));
                return true;
            }
        }

        public async Task<bool> RemoveAsync(TaskGroup entity)
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

        public async Task<IEnumerable<TaskGroup>> GetByProjectIdAsync(PaginationFilter paginationQuery, Guid projectId)
        {
            return await _repository.GetByProjectIdAsync(paginationQuery, projectId);
        }
    }
}
