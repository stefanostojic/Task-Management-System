using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories.UserProjectRepository;
using Task_Management_System.Services.ProjectRoleService;
using Task_Management_System.Services.ProjectService;
using Task_Management_System.Services.UserService;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.UserProjectService
{
    public class UserProjectService : IUserProjectService
    {
        private readonly IMapper mapper;
        private readonly IUserProjectRepository userProjectRepository;
        private readonly IUserService userService;
        private readonly IProjectService projectService;
        private readonly IProjectRoleService projectRoleService;

        public UserProjectService(IUserProjectRepository userProjectRepository, IUserService userService, IProjectService projectService, IProjectRoleService projectRoleService, IMapper mapper)
        {
            this.userProjectRepository = userProjectRepository;
            this.userService = userService;
            this.projectService = projectService;
            this.projectRoleService = projectRoleService;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<UserProject>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await userProjectRepository.GetAllAsync(paginationFilter);
        }

        public async Task<UserProject> GetByIdAsync(Guid userId, Guid projectId)
        {
            return await userProjectRepository.GetByIdAsync(userId, projectId);
        }

        public async Task<UserProject> AddAsync(UserProjectPostDto entity)
        {
            UserProjectPostDtoValidator validator = new UserProjectPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("UserProjectPostDTO", string.Join(". ", results.Errors));
            }

            var userExists = await userService.GetByIdAsync(entity.UserID);
            if (userExists == null)
            {
                throw new BadRequestException("User not found.");
            }

            var projectExists = await projectService.GetByIdAsync(entity.ProjectID);
            if (projectExists == null)
            {
                throw new BadRequestException("Project not found.");
            }

            var projectRoleExists = await projectRoleService.GetByIdAsync(entity.ProjectRoleID);
            if (projectRoleExists == null)
            {
                throw new BadRequestException("Project role not found.");
            }

            return await userProjectRepository.AddAsync(mapper.Map<UserProject>(entity));
        }

        public async Task<bool> UpdateAsync(UserProjectPutDto proPlanPutDto)
        {
            UserProjectPutDtoValidator validator = new UserProjectPutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            UserProject project = await userProjectRepository.GetByIdAsync(proPlanPutDto.UserID, proPlanPutDto.ProjectID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested UserProject with ID: {proPlanPutDto.UserID} and {proPlanPutDto.ProjectID}");
            }

            return await userProjectRepository.UpdateAsync(mapper.Map<UserProject>(proPlanPutDto)) != null;
        }

        public async Task<bool> RemoveAsync(UserProject entity)
        {
            var exists = userProjectRepository.GetByIdAsync(entity.UserID, entity.ProjectID);
            if (exists == null)
            {
                return false;
            }
            else
            {
                await userProjectRepository.RemoveAsync(entity);
                return true;
            }
        }

        public async Task<bool> RemoveByIdAsync(Guid userId, Guid projectId)
        {
            var entityToRemove = await userProjectRepository.GetByIdAsync(userId, projectId);
            if (entityToRemove == null)
            {
                return false;
            }
            else
            {
                await userProjectRepository.RemoveAsync(entityToRemove);
                return true;
            }
        }
    }
}
