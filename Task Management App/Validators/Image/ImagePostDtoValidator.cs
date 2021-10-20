using FluentValidation;
using Task_Management_System.Models.DTO.Image;

namespace Task_Management_System.Validators
{
    public class ImagePostDtoValidator : AbstractValidator<ImagePostDto>
    {
        public ImagePostDtoValidator()
        {
            RuleFor(p => p.FilePath)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The file path must be between 1 and 255 characters long.");
        }
    }
}
