using FluentValidation;
using Task_Management_System.Models.DTO.Block;

namespace Task_Management_System.Validators
{
    public class BlockPostDtoValidator : AbstractValidator<BlockPostDto>
    {
        public BlockPostDtoValidator()
        {
            RuleFor(ur => ur.User1ID)
                .NotNull();
            RuleFor(ur => ur.User2ID)
                .NotNull();
        }
    }
}
