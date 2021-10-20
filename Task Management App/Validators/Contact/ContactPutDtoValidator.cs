using FluentValidation;
using Task_Management_System.Models.DTO.Contact;

namespace Task_Management_System.Validators
{
    public class ContactPutDtoValidator : AbstractValidator<ContactPutDto>
    {
        public ContactPutDtoValidator()
        {
            RuleFor(ur => ur.User1ID)
                .NotNull();
            RuleFor(ur => ur.User2ID)
                .NotNull();
            RuleFor(e => e.Accepted)
                .NotNull();
        }
    }
}
