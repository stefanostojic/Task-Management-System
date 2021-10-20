using FluentValidation;
using System;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Validators
{
    public class UserTaskPutDtoValidator : AbstractValidator<UserTaskPutDto>
    {
        public UserTaskPutDtoValidator()
        {
            RuleFor(p => p.UserID)
                .NotNull();
            RuleFor(p => p.TaskID)
                .NotNull();
            RuleFor(p => p.TaskRoleID)
                .NotNull();
            RuleFor(t => t.EstimatedEndDate)
                .Must(t => t > DateTime.Now)
                .WithMessage("The estimated end date can't be before now.");
        }
    }
}
