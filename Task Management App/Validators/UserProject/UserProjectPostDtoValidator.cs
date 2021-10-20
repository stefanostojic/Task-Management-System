using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class UserProjectPostDtoValidator : AbstractValidator<UserProjectPostDto>
    {
        public UserProjectPostDtoValidator()
        {
            RuleFor(p => p.UserID)
                .NotNull();
            RuleFor(p => p.ProjectID)
                .NotNull();
            RuleFor(p => p.ProjectRoleID)
                .NotNull();
            RuleFor(p => p.Accepted)
                .NotNull()
                .WithMessage("The active status must be set.");
        }
    }
}
