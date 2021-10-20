using FluentValidation;
using System;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class TaskPostDtoValidator : AbstractValidator<TaskPostDto>
    {
        public TaskPostDtoValidator()
        {
            RuleFor(t => t.Name)
                .MinimumLength(1)
                .MaximumLength(15);
            RuleFor(t => t.Description)
                .MinimumLength(1)
                .MaximumLength(255);
            RuleFor(t => t.Finished)
                .NotNull();
            RuleFor(t => t.DueDate)
                .Must(t => t > DateTime.Now)
                .WithMessage("The due date of the task can't be before it's creation.");
        }
    }
}
