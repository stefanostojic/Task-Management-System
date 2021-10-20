using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class TaskRoleProfile : Profile
    {
        public TaskRoleProfile()
        {
            CreateMap<TaskRolePostDto, TaskRole>();
            CreateMap<TaskRolePutDto, TaskRole>();
            CreateMap<TaskRole, TaskRoleResponseDto>();
        }
    }
}
