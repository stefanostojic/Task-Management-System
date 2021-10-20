using FluentValidation;
using Task_Management_System.Models.DTO.Label;

namespace Task_Management_System.Validators
{
    public class LabelPostDtoValidator : AbstractValidator<LabelPostDto>
    {
        public LabelPostDtoValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The name must be between 1 and 255 characters long.");
        }
    }
}
