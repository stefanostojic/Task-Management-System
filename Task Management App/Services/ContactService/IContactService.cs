using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Contact;

namespace Task_Management_System.Services.ContactService
{
    public interface IContactService
    {
        Task<PagedResponse<Contact>> GetAllAsync(PaginationFilter paginationFilter);
        Task<Contact> GetByIdAsync(Guid user1Id, Guid user2Id);
        Task<Contact> AddAsync(ContactPostDto entity);
        Task<bool> UpdateAsync(ContactPutDto entity);
        Task<bool> RemoveAsync(Contact entity);
        Task<bool> RemoveByIdAsync(Guid user1Id, Guid user2Id);
    }
}
