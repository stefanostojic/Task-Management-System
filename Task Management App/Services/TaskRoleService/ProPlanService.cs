using AutoMapper;
using FluentValidation.Results;
using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.TaskRoleService
{
    public class TaskRoleService : GenericService<TaskRole>, ITaskRoleService
    {
        private readonly IMapper mapper;

        public TaskRoleService(IGenericRepository<TaskRole> genericRepository, IMapper mapper)
            : base(genericRepository)
        {
            this.mapper = mapper;
        }

        public async Task<TaskRole> AddAsync(TaskRolePostDto entity)
        {
            TaskRolePostDtoValidator validator = new TaskRolePostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("TaskRolePostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<TaskRole>(entity));
        }

        public async Task<bool> UpdateAsync(TaskRolePutDto taskRolePutDto)
        {
            TaskRolePutDtoValidator validator = new TaskRolePutDtoValidator();
            ValidationResult results = validator.Validate(taskRolePutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("taskRolePutDTO", string.Join(". ", results.Errors));
            }

            TaskRole project = await _repository.GetByIdAsync(taskRolePutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested TaskRole with ID: {taskRolePutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<TaskRole>(taskRolePutDto)) != null;
        }
    }
}
