using FluentValidation;
using Task_Management_System.Models.DTO.Image;

namespace Task_Management_System.Validators
{
    public class ImagePutDtoValidator : AbstractValidator<ImagePutDto>
    {
        public ImagePutDtoValidator()
        {
            RuleFor(p => p.ID)
                .NotNull();
            RuleFor(p => p.FilePath)
                .MinimumLength(1)
                .MaximumLength(255)
                .WithMessage("The file path must be between 1 and 255 characters long.");
        }
    }
}
