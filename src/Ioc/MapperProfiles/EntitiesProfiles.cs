#region

using AutoMapper;
using Model.Entities;
using Model.ViewModels;

#endregion

namespace Ioc.MapperProfiles
{
    public class EntitiesProfiles : Profile
    {
        public EntitiesProfiles()
        {
            CreateMap<Post, PostViewModel>()
                .ReverseMap();

            CreateMap<Comment, CommentViewModel>()
                .ReverseMap();
        }
    }
}