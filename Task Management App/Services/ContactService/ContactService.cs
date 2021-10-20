using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Contact;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories;
using Task_Management_System.Repositories.ContactRepository;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository userRoleRepository;
        private readonly IMapper mapper;

        public ContactService(IContactRepository repository, IMapper mapper)
        {
            userRoleRepository = repository;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<Contact>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await userRoleRepository.GetAllAsync(paginationFilter);
        }

        public async Task<Contact> GetByIdAsync(Guid user1Id, Guid user2Id)
        {
            return await userRoleRepository.GetByIdAsync(user1Id, user2Id);
        }

        public async Task<Contact> AddAsync(ContactPostDto entity)
        {
            ContactPostDtoValidator validator = new ContactPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("ContactPostDTO", string.Join(". ", results.Errors));
            }

            return await userRoleRepository.AddAsync(mapper.Map<Contact>(entity));
        }

        public async Task<bool> UpdateAsync(ContactPutDto entity)
        {
            ContactPutDtoValidator validator = new ContactPutDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("ContactPutDTO", string.Join(". ", results.Errors));
            }

            var exists = await userRoleRepository.GetByIdAsync(entity.User1ID, entity.User2ID);
            if (exists == null)
                return false;
            
            await userRoleRepository.UpdateAsync(mapper.Map<Contact>(entity));
            return true;
        }

        public async Task<bool> RemoveAsync(Contact entity)
        {
            var exists = userRoleRepository.GetByIdAsync(entity.User1ID, entity.User2ID);
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

        public async Task<bool> RemoveByIdAsync(Guid user1Id, Guid user2Id)
        {
            var entityToRemove = await userRoleRepository.GetByIdAsync(user1Id, user2Id);
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
