#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Dtos;
using Model.ViewModels;

#endregion

namespace Service.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> GetAll();

        Task<CommentViewModel> Get(Guid id);

        Task<IEnumerable<CommentViewModel>> GetByPostId(Guid postId);

        Task<CommentViewModel> Post(CreateCommentDto comment);

        Task Put(UpdateCommentDto comment);

        Task Delete(Guid id);
    }
}