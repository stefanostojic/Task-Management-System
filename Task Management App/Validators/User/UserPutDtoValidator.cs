using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class UserPutDtoValidator : AbstractValidator<UserPutDto>
    {
        public UserPutDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull();
            RuleFor(p => p.FirstName)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The firstname must be between 1 and 15 characters long.");
            RuleFor(p => p.LastName)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The lastname must be between 1 and 15 characters long.");
            RuleFor(p => p.Password)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The password must be between 1 and 15 characters long.");
        }
    }
}
