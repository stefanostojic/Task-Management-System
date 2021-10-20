using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Task_Management_System.Models.DTO.UserRole;
using Task_Management_System.Validators;

namespace Task_Management_System.Utils
{
    public static class ValidationServiceCollectionExtension
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserRolePostDto>, UserRolePostDtoValidator>();
            services.AddTransient<IValidator<UserRolePutDto>, UserRolePutDtoValidator>();
        }
    }
}
