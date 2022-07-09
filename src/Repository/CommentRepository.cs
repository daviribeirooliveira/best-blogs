#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Contexts;
using Repository.Interfaces;

#endregion

namespace Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly BlogContext _blogContext;

        public CommentRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public async Task<IEnumerable<Comment>> GetByPostId(Guid postId)
        {
            return await _blogContext.Comments.Where(comment => comment.PostId == postId).ToListAsync();
        }
    }
}