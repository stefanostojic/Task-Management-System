using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.UserRole;
using Task_Management_System.Repositories.UserRoleRepository;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IMapper mapper;

        public UserRoleService(IUserRoleRepository repository, IMapper mapper)
        {
            userRoleRepository = repository;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<UserRole>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await userRoleRepository.GetAllAsync(paginationFilter);
        }

        public async Task<UserRole> GetByIdAsync(Guid id)
        {
            return await userRoleRepository.GetByIdAsync(id);
        }

        public async Task<UserRole> AddAsync(UserRolePostDto entity)
        {
            UserRolePostDtoValidator validator = new UserRolePostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("UserRolePostDTO", string.Join(". ", results.Errors));
            }

            return await userRoleRepository.AddAsync(mapper.Map<UserRole>(entity));
        }

        public async Task<bool> UpdateAsync(UserRolePutDto entity)
        {
            UserRolePutDtoValidator validator = new UserRolePutDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("UserRolePutDTO", string.Join(". ", results.Errors));
            }

            var exists = await userRoleRepository.GetByIdAsync(entity.ID);
            if (exists == null)
                return false;
            else
            {
                await userRoleRepository.UpdateAsync(mapper.Map<UserRole>(entity));
                return true;
            }
        }

        public async Task<bool> RemoveAsync(UserRole entity)
        {
            var exists = userRoleRepository.GetByIdAsync(entity.Id);
            if (exists == null)
            {
                return false;
            }
            else
            {
                await userRoleRepository.RemoveAsync(entity);
                return true;
            }
        }

        public async Task<bool> RemoveByIdAsync(Guid id)
        {
            var entityToRemove = await userRoleRepository.GetByIdAsync(id);
            if (entityToRemove == null)
            {
                return false;
            }
            else
            {
                await userRoleRepository.RemoveAsync(entityToRemove);
                return true;
            }
        }
    }
}
