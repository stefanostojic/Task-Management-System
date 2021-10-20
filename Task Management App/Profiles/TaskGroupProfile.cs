using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class TaskGroupProfile : Profile
    {
        public TaskGroupProfile()
        {
            CreateMap<TaskGroupPostDto, TaskGroup>();
            CreateMap<TaskGroupPutDto, TaskGroup>();
            CreateMap<TaskGroup, TaskGroupResponseDto>();
            CreateMap<TaskGroup, TaskGroupWithTasksResponseDto>()
                .ForMember(
                    dest => dest.Tasks,
                    opt => opt.MapFrom(src => src.Tasks));
        }
    }
}
