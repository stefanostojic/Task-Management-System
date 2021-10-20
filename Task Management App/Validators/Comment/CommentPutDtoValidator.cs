using FluentValidation;
using Task_Management_System.Models.DTO.Comment;

namespace Task_Management_System.Validators
{
    public class CommentPutDtoValidator : AbstractValidator<CommentPutDto>
    {
        public CommentPutDtoValidator()
        {
            RuleFor(p => p.ID)
                .NotNull();
            RuleFor(p => p.Text)
                .MinimumLength(1)
                .MaximumLength(15)
                .WithMessage("The text must be between 1 and 255 characters long.");
            RuleFor(p => p.UserID)
                .NotNull();
            RuleFor(p => p.TaskID)
                .NotNull();
        }
    }
}
