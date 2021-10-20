using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class ProPlanPostDtoValidator : AbstractValidator<ProPlanPostDto>
    {
        public ProPlanPostDtoValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The name must be between 1 and 15 characters long.");
            RuleFor(p => p.Price)
                .GreaterThan(1)
                .LessThan(10000)
                .WithMessage("The price must be between 1 and 10000.");
            RuleFor(p => p.Active)
                .NotNull()
                .WithMessage("The active status must be set.");
        }
    }
}
