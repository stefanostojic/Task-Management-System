using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.Dtos;

namespace Task_Management_System.Profiles
{
    public class ProPlanProfile : Profile
    {
        public ProPlanProfile()
        {
            CreateMap<ProPlanPostDto, ProPlan>();
            CreateMap<ProPlanPutDto, ProPlan>();
            CreateMap<ProPlan, ProPlanResponseDto>();
        }
    }
}
