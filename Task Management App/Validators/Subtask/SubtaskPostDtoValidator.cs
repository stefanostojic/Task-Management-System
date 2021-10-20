using FluentValidation;
using Task_Management_System.Models.DTO.Subtask;

namespace Task_Management_System.Validators
{
    public class SubtaskPostDtoValidator : AbstractValidator<SubtaskPostDto>
    {
        public SubtaskPostDtoValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The name must be between 1 and 255 characters long.");
            RuleFor(p => p.Finished)
                .NotNull();
            RuleFor(p => p.TaskID)
                .NotNull();
        }
    }
}
