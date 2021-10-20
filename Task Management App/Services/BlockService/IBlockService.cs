using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Block;

namespace Task_Management_System.Services.BlockService
{
    public interface IBlockService
    {
        Task<PagedResponse<Block>> GetAllAsync(PaginationFilter paginationFilter);
        Task<Block> GetByIdAsync(Guid user1Id, Guid user2Id);
        Task<Block> AddAsync(BlockPostDto entity);
        Task<bool> RemoveAsync(Block entity);
        Task<bool> RemoveByIdAsync(Guid user1Id, Guid user2Id);
    }
}
