using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Block;
using Task_Management_System.Repositories.BlockRepository;
using Task_Management_System.Services.UserService;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.BlockService
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository userRoleRepository;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public BlockService(IBlockRepository repository, IUserService userService, IMapper mapper)
        {
            userRoleRepository = repository;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<Block>> GetAllAsync(PaginationFilter paginationFilter)
        {
            if (paginationFilter.PageNumber < 1)
            {
                throw new BadRequestException("Page number can't be less than 1");
            }

            return await userRoleRepository.GetAllAsync(paginationFilter);
        }

        public async Task<Block> GetByIdAsync(Guid user1Id, Guid user2Id)
        {
            return await userRoleRepository.GetByIdAsync(user1Id, user2Id);
        }

        public async Task<Block> AddAsync(BlockPostDto entity)
        {
            BlockPostDtoValidator validator = new BlockPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("BlockPostDTO", string.Join(". ", results.Errors));
            }

            var user2Exists = await userService.GetByIdAsync(entity.User2ID);
            if (user2Exists == null)
            {
                throw new BadRequestException("The user can't be blocked because he doesn't exist.");
            }

            entity.Date = DateTime.Now;

            return await userRoleRepository.AddAsync(mapper.Map<Block>(entity));
        }

        public async Task<bool> RemoveAsync(Block entity)
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
