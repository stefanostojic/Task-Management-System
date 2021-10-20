using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class UserPostDtoValidator : AbstractValidator<UserPostDto>
    {
        public UserPostDtoValidator()
        {
            RuleFor(p => p.FirstName)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The firstname must be between 1 and 15 characters long.");
            RuleFor(p => p.LastName)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The lastname must be between 1 and 15 characters long.");
            RuleFor(p => p.Email)
                .MinimumLength(1)
                .MaximumLength(30)
                .WithMessage("The email must be between 1 and 30 characters long.");
            RuleFor(p => p.Password)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The password must be between 1 and 15 characters long.");
        }
    }
}
