#region

using Model.Entities;
using Repository.Contexts;
using Repository.Interfaces;

#endregion

namespace Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext blogContext) : base(blogContext)
        {
        }
    }
}