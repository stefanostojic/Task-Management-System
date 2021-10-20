using FluentValidation;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class TaskGroupPutDtoValidator : AbstractValidator<TaskGroupPutDto>
    {
        public TaskGroupPutDtoValidator()
        {
            RuleFor(tg => tg.ID)
                .NotNull();
            RuleFor(tg => tg.Name)
                .MinimumLength(1)
                .MaximumLength(15);
            RuleFor(tg => tg.Description)
                .MinimumLength(1)
                .MaximumLength(255);
        }
    }
}
