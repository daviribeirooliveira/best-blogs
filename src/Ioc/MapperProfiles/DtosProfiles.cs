using AutoMapper;
using Model.Dtos;
using Model.Entities;

namespace Ioc.MapperProfiles
{
    public class DtosProfiles : Profile
    {
        public DtosProfiles()
        {
            CreateMap<CreatePostDto, Post>()
                .ReverseMap();

            CreateMap<UpdatePostDto, Post>()
                .ForAllMembers(expression => expression.Condition((_, _, srcMember) => srcMember is not null));

            CreateMap<CreateCommentDto, Comment>()
                .ReverseMap();

            CreateMap<UpdateCommentDto, Comment>()
                .ForAllMembers(expression => expression.Condition((_, _, srcMember) => srcMember is not null));
        }
    }
}