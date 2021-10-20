using AutoMapper;
using FluentValidation.Results;
using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.ProjectRole;
using Task_Management_System.Repositories;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.ProjectRoleService
{
    public class ProjectRoleService : GenericService<ProjectRole>, IProjectRoleService
    {
        private readonly IMapper mapper;

        public ProjectRoleService(IGenericRepository<ProjectRole> genericRepository, IMapper mapper)
            : base(genericRepository)
        {
            this.mapper = mapper;
        }

        public async Task<ProjectRole> AddAsync(ProjectRolePostDto entity)
        {
            ProjectRolePostDtoValidator validator = new ProjectRolePostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("ProjectRolePostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<ProjectRole>(entity));
        }

        public async Task<bool> UpdateAsync(ProjectRolePutDto proPlanPutDto)
        {
            ProjectRolePutDtoValidator validator = new ProjectRolePutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            ProjectRole project = await _repository.GetByIdAsync(proPlanPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested ProjectRole with ID: {proPlanPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<ProjectRole>(proPlanPutDto)) != null;
        }
    }
}
