using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectPostDto, Project>();
            CreateMap<ProjectPutDto, Project>();
            CreateMap<Project, ProjectResponseDto>()
                .ForMember(
                    dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        }
    }
}
