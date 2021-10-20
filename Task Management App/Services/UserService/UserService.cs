using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories.UserRepository;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<User>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await _repository.GetAllAsync(paginationFilter);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<User> AddAsync(UserPostDto entity)
        {
            UserPostDtoValidator validator = new UserPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("UserPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<User>(entity));
        }

        public async Task<bool> UpdateAsync(UserPutDto entity)
        {
            var exists = await _repository.GetByIdAsync(entity.Id);
            if (exists == null)
                return false;
            else
            {
                await _repository.UpdateAsync(mapper.Map<User>(entity));
                return true;
            }
        }

        public async Task<bool> RemoveAsync(User entity)
        {
            var exists = _repository.GetByIdAsync(entity.Id);
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
