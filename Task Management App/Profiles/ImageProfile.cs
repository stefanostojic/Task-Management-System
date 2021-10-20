using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Image;

namespace Task_Management_System.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImagePostDto, Image>();
            CreateMap<ImagePutDto, Image>();
            CreateMap<Image, ImageResponseDto>();
        }
    }
}
