using AutoMapper;
using FluentValidation.Results;
using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Label;
using Task_Management_System.Repositories;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.LabelService
{
    public class LabelService : GenericService<Label>, ILabelService
    {
        private readonly IMapper mapper;

        public LabelService(IGenericRepository<Label> genericRepository, IMapper mapper)
            : base(genericRepository)
        {
            this.mapper = mapper;
        }

        public async Task<Label> AddAsync(LabelPostDto entity)
        {
            LabelPostDtoValidator validator = new LabelPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("LabelPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<Label>(entity));
        }

        public async Task<bool> UpdateAsync(LabelPutDto proPlanPutDto)
        {
            LabelPutDtoValidator validator = new LabelPutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            Label project = await _repository.GetByIdAsync(proPlanPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested Label with ID: {proPlanPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<Label>(proPlanPutDto)) != null;
        }
    }
}
