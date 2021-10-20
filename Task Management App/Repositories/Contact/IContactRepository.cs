using System;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;

namespace Task_Management_System.Repositories.ContactRepository
{
    public interface IContactRepository 
    {
        Task<PagedResponse<Contact>> GetAllAsync(PaginationFilter paginationFilter);
        Task<Contact> GetByIdAsync(Guid user1Id, Guid user2Id);
        Task<Contact> AddAsync(Contact entity);
        Task<Contact> UpdateAsync(Contact entity);
        Task<bool> RemoveAsync(Contact entity);
        Task<bool> RemoveByIdAsync(Guid user1Id, Guid user2Id);
    }
}
