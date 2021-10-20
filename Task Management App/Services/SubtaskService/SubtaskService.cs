
using AutoMapper;
using FluentValidation.Results;
using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Subtask;
using Task_Management_System.Repositories;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.SubtaskService
{
    public class SubtaskService : GenericService<Subtask>, ISubtaskService
    {
        private readonly IMapper mapper;

        public SubtaskService(IGenericRepository<Subtask> genericRepository, IMapper mapper)
            : base(genericRepository)
        {
            this.mapper = mapper;
        }

        public async Task<Subtask> AddAsync(SubtaskPostDto entity)
        {
            SubtaskPostDtoValidator validator = new SubtaskPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("SubtaskPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<Subtask>(entity));
        }

        public async Task<bool> UpdateAsync(SubtaskPutDto proPlanPutDto)
        {
            SubtaskPutDtoValidator validator = new SubtaskPutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            Subtask project = await _repository.GetByIdAsync(proPlanPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested Subtask with ID: {proPlanPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<Subtask>(proPlanPutDto)) != null;
        }
    }
}
