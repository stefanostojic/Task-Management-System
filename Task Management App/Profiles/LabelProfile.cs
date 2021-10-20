using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Label;

namespace Task_Management_System.Profiles
{
    public class LabelProfile : Profile
    {
        public LabelProfile()
        {
            CreateMap<LabelPostDto, Label>();
            CreateMap<LabelPutDto, Label>();
            CreateMap<Label, LabelResponseDto>();
        }
    }
}
