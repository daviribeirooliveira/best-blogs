#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Dtos;
using Model.ViewModels;

#endregion

namespace Api.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetAll();

        Task<PostViewModel> Get(Guid id);

        Task<PostViewModel> Post(CreatePostDto post);

        Task Put(UpdatePostDto post);

        Task Delete(Guid id);
    }
}