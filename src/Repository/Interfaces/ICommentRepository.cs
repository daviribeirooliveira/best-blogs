#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Entities;

#endregion

namespace Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByPostId(Guid postId);
    }
}