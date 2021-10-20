using FluentValidation;
using Task_Management_System.Models.DTO.UserRole;

namespace Task_Management_System.Validators
{
    public class UserRolePutDtoValidator : AbstractValidator<UserRolePutDto>
    {
        public UserRolePutDtoValidator()
        {
            RuleFor(ur => ur.ID)
                .NotNull();
            RuleFor(userRole => userRole.Name)
                .MinimumLength(1)
                .MaximumLength(15);
        }
    }
}
