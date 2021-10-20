using AutoMapper;
using Task_Management_System.Models;
using Task_Management_System.Models.DTO.Comment;

namespace Task_Management_System.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentPostDto, Comment>();
            CreateMap<CommentPutDto, Comment>();
            CreateMap<Comment, CommentResponseDto>()
                .ForMember(
                    dest => dest.UserFullName,
                    opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        }
    }
}
