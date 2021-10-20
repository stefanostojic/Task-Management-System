using AutoMapper;
using System.Linq;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskPostDto, Task>();
            CreateMap<TaskPutDto, Task>();
            CreateMap<Task, TaskResponseDto>()
                .ForMember(dest => dest.Assignees, opt => opt.MapFrom(src => src.UserTasks.Select(ut => ut.User).ToList())); 
        }
    }
}
