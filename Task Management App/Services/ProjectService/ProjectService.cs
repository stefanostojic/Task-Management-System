using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories;
using Task_Management_System.Repositories.ProjectRepository;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _repository;
        private readonly IMapper mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<Project>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await ((IProjectRepository)_repository).GetAllAsync(paginationFilter);
        }

        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Project> AddAsync(ProjectPostDto entity)
        {
            ProjectPostDtoValidator validator = new ProjectPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("ProjectPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<Project>(entity));
        }

        public async Task<bool> UpdateAsync(ProjectPutDto projectPutDto)
        {
            ProjectPutDtoValidator validator = new ProjectPutDtoValidator();
            ValidationResult results = validator.Validate(projectPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("projectPutDTO", string.Join(". ", results.Errors));
            }

            Project project = await _repository.GetByIdAsync(projectPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested Project with ID: {projectPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<Project>(projectPutDto)) != null;
        }

        public async Task<bool> RemoveAsync(Project entity)
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
