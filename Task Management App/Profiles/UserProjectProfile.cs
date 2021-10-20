using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class UserProjectProfile : Profile
    {
        public UserProjectProfile()
        {
            CreateMap<UserProjectPostDto, UserProject>();
            CreateMap<UserProjectPutDto, UserProject>();
            CreateMap<UserProject, UserProjectResponseDto>();
        }
    }
}
