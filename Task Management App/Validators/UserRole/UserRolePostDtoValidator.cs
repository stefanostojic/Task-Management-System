using FluentValidation;
using Task_Management_System.Models.DTO.UserRole;

namespace Task_Management_System.Validators
{
    public class UserRolePostDtoValidator : AbstractValidator<UserRolePostDto>
    {
        public UserRolePostDtoValidator()
        {
            RuleFor(userRole => userRole.Name)
                .MinimumLength(1)
                .MaximumLength(15);
        }
    }
}
