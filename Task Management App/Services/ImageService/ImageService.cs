using AutoMapper;
using FluentValidation.Results;
using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Image;
using Task_Management_System.Repositories;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.ImageService
{
    public class ImageService : GenericService<Image>, IImageService
    {
        private readonly IMapper mapper;

        public ImageService(IGenericRepository<Image> genericRepository, IMapper mapper)
            : base(genericRepository)
        {
            this.mapper = mapper;
        }

        public async Task<Image> AddAsync(ImagePostDto entity)
        {
            ImagePostDtoValidator validator = new ImagePostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("ImagePostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<Image>(entity));
        }

        public async Task<bool> UpdateAsync(ImagePutDto proPlanPutDto)
        {
            ImagePutDtoValidator validator = new ImagePutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            Image project = await _repository.GetByIdAsync(proPlanPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested Image with ID: {proPlanPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<Image>(proPlanPutDto)) != null;
        }
    }
}
