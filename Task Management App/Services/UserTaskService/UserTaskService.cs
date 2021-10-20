using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories.UserTaskRepository;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.UserTaskService
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IMapper mapper;
        private readonly IUserTaskRepository userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.userTaskRepository = userTaskRepository;
        }

        public async Task<PagedResponse<UserTask>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await userTaskRepository.GetAllAsync(paginationFilter);
        }

        public async Task<UserTask> GetByIdAsync(Guid userId, Guid projectId)
        {
            return await userTaskRepository.GetByIdAsync(userId, projectId);
        }

        public async Task<UserTask> AddAsync(UserTaskPostDto entity)
        {
            UserTaskPostDtoValidator validator = new UserTaskPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("UserTaskPostDTO", string.Join(". ", results.Errors));
            }

            return await userTaskRepository.AddAsync(mapper.Map<UserTask>(entity));
        }

        public async Task<bool> UpdateAsync(UserTaskPutDto proPlanPutDto)
        {
            UserTaskPutDtoValidator validator = new UserTaskPutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            UserTask project = await userTaskRepository.GetByIdAsync(proPlanPutDto.UserID, proPlanPutDto.TaskID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested UserTask with ID: {proPlanPutDto.UserID} and {proPlanPutDto.TaskID}");
            }

            return await userTaskRepository.UpdateAsync(mapper.Map<UserTask>(proPlanPutDto)) != null;
        }

        public async Task<bool> RemoveAsync(UserTask entity)
        {
            var exists = userTaskRepository.GetByIdAsync(entity.UserID, entity.TaskID);
            if (exists == null)
            {
                return false;
            }
            else
            {
                await userTaskRepository.RemoveAsync(entity);
                return true;
            }
        }

        public async Task<bool> RemoveByIdAsync(Guid userId, Guid projectId)
        {
            var entityToRemove = await userTaskRepository.GetByIdAsync(userId, projectId);
            if (entityToRemove == null)
            {
                return false;
            }
            else
            {
                await userTaskRepository.RemoveAsync(entityToRemove);
                return true;
            }
        }
    }
}
