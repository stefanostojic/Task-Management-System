using FluentValidation;
using Task_Management_System.Models.DTO.ProjectRole;

namespace Task_Management_System.Validators
{
    public class ProjectRolePostDtoValidator : AbstractValidator<ProjectRolePostDto>
    {
        public ProjectRolePostDtoValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(1)
                .MaximumLength(15);
        }
    }
}
