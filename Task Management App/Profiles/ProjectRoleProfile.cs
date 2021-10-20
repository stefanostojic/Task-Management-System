using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.ProjectRole;

namespace Task_Management_System.Profiles
{
    public class ProjectRoleProfile : Profile
    {
        public ProjectRoleProfile()
        {
            CreateMap<ProjectRolePostDto, ProjectRole>();
            CreateMap<ProjectRolePutDto, ProjectRole>();
            CreateMap<ProjectRole, ProjectRoleResponseDto>();
        }
    }
}
