using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;
using FluentValidation;

namespace Task_Management_System.Validators
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(userRole => userRole.Name).MinimumLength(1);
        }
    }
}
