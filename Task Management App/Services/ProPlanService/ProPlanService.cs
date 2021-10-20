using AutoMapper;
using FluentValidation.Results;
using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Repositories;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.ProPlanService
{
    public class ProPlanService : GenericService<ProPlan>, IProPlanService
    {
        private readonly IMapper mapper;

        public ProPlanService(IGenericRepository<ProPlan> genericRepository, IMapper mapper)
            : base(genericRepository)
        {
            this.mapper = mapper;
        }

        public async Task<ProPlan> AddAsync(ProPlanPostDto entity)
        {
            ProPlanPostDtoValidator validator = new ProPlanPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("ProPlanPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<ProPlan>(entity));
        }

        public async Task<bool> UpdateAsync(ProPlanPutDto proPlanPutDto)
        {
            ProPlanPutDtoValidator validator = new ProPlanPutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            ProPlan project = await _repository.GetByIdAsync(proPlanPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested ProPlan with ID: {proPlanPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<ProPlan>(proPlanPutDto)) != null;
        }
    }
}
