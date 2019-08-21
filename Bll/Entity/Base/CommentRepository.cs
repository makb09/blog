using Bll.Entity.Abstract;
using Bll.Entity.Models;
using Dal.EntityCore.Base;

namespace Bll.Entity.Base
{
    public class CommentRepository : EntityBaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }
    }
}
