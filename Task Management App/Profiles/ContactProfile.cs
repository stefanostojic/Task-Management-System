using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Contact;

namespace Task_Management_System.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactPostDto, Contact>();
            CreateMap<ContactPutDto, Contact>();
            CreateMap<Contact, ContactResponseDto>()
                .ForMember(
                    dest => dest.User1FullName,
                    opt => opt.MapFrom(src => src.User1.FirstName + " " + src.User1.LastName))
                .ForMember(
                    dest => dest.User2FullName,
                    opt => opt.MapFrom(src => src.User2.FirstName + " " + src.User2.LastName));
        }
    }
}
