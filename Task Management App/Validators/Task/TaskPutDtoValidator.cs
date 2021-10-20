using FluentValidation;
using System;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class TaskPutDtoValidator : AbstractValidator<TaskPutDto>
    {
        public TaskPutDtoValidator()
        {
            RuleFor(t => t.ID)
                .NotNull();
            RuleFor(t => t.Name)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The name must be between 1 and 15 characters long.");
            RuleFor(t => t.Description)
                .MinimumLength(1)
                .MaximumLength(255)
                .WithMessage("The name must be between 1 and 255 characters long.");
            RuleFor(t => t.Finished)
                .NotNull();
            RuleFor(t => t.DueDate)
                .Must(t => t > DateTime.Now)
                .WithMessage("The due date of the task can't be before it's creation.");
        }
    }
}
