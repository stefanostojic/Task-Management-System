using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Services.ProjectService
{
    public interface IProjectService 
    {
        Task<PagedResponse<Project>> GetAllAsync(PaginationFilter paginationFilter);
        Task<Project> GetByIdAsync(Guid id);
        Task<Project> AddAsync(ProjectPostDto entity);
        Task<bool> UpdateAsync(ProjectPutDto entity);
        Task<bool> RemoveAsync(Project entity);
        Task<bool> RemoveByIdAsync(Guid id);
    }
}
