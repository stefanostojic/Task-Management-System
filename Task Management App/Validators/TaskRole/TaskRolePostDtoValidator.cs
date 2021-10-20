using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class TaskRolePostDtoValidator : AbstractValidator<TaskRolePostDto>
    {
        public TaskRolePostDtoValidator()
        {
            RuleFor(tr => tr.Name)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The name must be between 1 and 15 characters long.");
        }
    }
}
