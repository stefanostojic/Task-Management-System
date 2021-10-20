using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
            CreateMap<User, UserResponseDto>();
        }
    }
}
