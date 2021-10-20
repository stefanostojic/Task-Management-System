using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class ProjectPostDtoValidator : AbstractValidator<ProjectPostDto>
    {
        public ProjectPostDtoValidator()
        {
            RuleFor(Project => Project.Name)
                .MinimumLength(1)
                .MaximumLength(15);
            RuleFor(Project => Project.Description)
                .MinimumLength(1)
                .MaximumLength(255);
        }
    }
}
