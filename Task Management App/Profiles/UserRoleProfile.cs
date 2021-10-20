using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.UserRole;

namespace Task_Management_System.Profiles
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRolePostDto, UserRole>();
            CreateMap<UserRolePutDto, UserRole>();
            CreateMap<UserRole, UserRoleResponseDto>();
        }
    }
}
