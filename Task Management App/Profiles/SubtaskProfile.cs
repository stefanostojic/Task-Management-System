using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Subtask;

namespace Task_Management_System.Profiles
{
    public class SubtaskProfile : Profile
    {
        public SubtaskProfile()
        {
            CreateMap<SubtaskPostDto, Subtask>();
            CreateMap<SubtaskPutDto, Subtask>();
            CreateMap<Subtask, SubtaskResponseDto>();
        }
    }
}
