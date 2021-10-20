using AutoMapper;
using FluentValidation.Results;
using System.Threading.Tasks;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Comment;
using Task_Management_System.Repositories;
using Task_Management_System.Validators;

namespace Task_Management_System.Services.CommentService
{
    public class CommentService : GenericService<Comment>, ICommentService
    {
        private readonly IMapper mapper;

        public CommentService(IGenericRepository<Comment> genericRepository, IMapper mapper)
            : base(genericRepository)
        {
            this.mapper = mapper;
        }

        public async Task<Comment> AddAsync(CommentPostDto entity)
        {
            CommentPostDtoValidator validator = new CommentPostDtoValidator();
            ValidationResult results = validator.Validate(entity);

            if (!results.IsValid)
            {
                throw new ValidationException("CommentPostDTO", string.Join(". ", results.Errors));
            }

            return await _repository.AddAsync(mapper.Map<Comment>(entity));
        }

        public async Task<bool> UpdateAsync(CommentPutDto proPlanPutDto)
        {
            CommentPutDtoValidator validator = new CommentPutDtoValidator();
            ValidationResult results = validator.Validate(proPlanPutDto);

            if (!results.IsValid)
            {
                throw new ValidationException("proPlanPutDTO", string.Join(". ", results.Errors));
            }

            Comment project = await _repository.GetByIdAsync(proPlanPutDto.ID);
            if (project == null)
            {
                throw new NotFoundException($"The server can not find the requested Comment with ID: {proPlanPutDto.ID}");
            }

            return await _repository.UpdateAsync(mapper.Map<Comment>(proPlanPutDto)) != null;
        }
    }
}
