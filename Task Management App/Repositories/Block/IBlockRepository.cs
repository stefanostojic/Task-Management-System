using System;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.BlockRepository
{
    public interface IBlockRepository 
    {
        Task<PagedResponse<Block>> GetAllAsync(PaginationFilter paginationFilter);
        Task<Block> GetByIdAsync(Guid user1Id, Guid user2Id);
        Task<Block> AddAsync(Block entity);
        Task<Block> UpdateAsync(Block entity);
        Task<bool> RemoveAsync(Block entity);
        Task<bool> RemoveByIdAsync(Guid user1Id, Guid user2Id);
    }
}
