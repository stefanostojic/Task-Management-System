using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories;
using Task_Management_System.Repositories.TaskRepository;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.TaskService
{
    public class TaskService : GenericService<Models.Task>, ITaskService
    {
        private readonly IMapper mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
            : base(taskRepository)
        {
            this.mapper = mapper;
        }

        public async Task<PagedResponse<Models.Task>> GetAllAsync(PaginationFilter paginationFilter, Guid taskGroupId)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }
                
            return await ((ITaskRepository)_repository).GetAllAsync(paginationFilter, taskGroupId);
        }

        public async Task<Models.Task> AddAsync(TaskPostDto entity)
        {
            TaskPostDtoValidator validator = new TaskPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("TaskPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<Models.Task>(entity));
        }

        public async Task<bool> UpdateAsync(TaskPutDto taskPutDto)
        {
            TaskPutDtoValidator validator = new TaskPutDtoValidator();
            ValidationResult results = validator.Validate(taskPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("taskPutDTO", string.Join(". ", results.Errors));
            }

            Models.Task project = await _repository.GetByIdAsync(taskPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested Task with ID: {taskPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<Models.Task>(taskPutDto)) != null;
        }
    }
}
