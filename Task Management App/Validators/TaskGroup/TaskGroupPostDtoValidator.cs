using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class TaskGroupPostDtoValidator : AbstractValidator<TaskGroupPostDto>
    {
        public TaskGroupPostDtoValidator()
        {
            RuleFor(tg => tg.Name)
                .MinimumLength(1)
                .MaximumLength(15);
            RuleFor(tg => tg.Description)
                .MinimumLength(1)
                .MaximumLength(255);
        }
    }
}
