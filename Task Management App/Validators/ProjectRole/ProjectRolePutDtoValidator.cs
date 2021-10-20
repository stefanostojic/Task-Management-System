using FluentValidation;
using Task_Management_System.Models.DTO.ProjectRole;

namespace Task_Management_System.Validators
{
    public class ProjectRolePutDtoValidator : AbstractValidator<ProjectRolePutDto>
    {
        public ProjectRolePutDtoValidator()
        {
            RuleFor(ur => ur.ID)
                .NotNull();
            RuleFor(p => p.Name)
                .MinimumLength(1)
                .MaximumLength(15);
        }
    }
}
