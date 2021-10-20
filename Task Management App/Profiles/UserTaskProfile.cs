using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class UserTaskProfile : Profile
    {
        public UserTaskProfile()
        {
            CreateMap<UserTaskPostDto, UserTask>();
            CreateMap<UserTaskPutDto, UserTask>();
            CreateMap<UserTask, UserTaskResponseDto>();
        }
    }
}
