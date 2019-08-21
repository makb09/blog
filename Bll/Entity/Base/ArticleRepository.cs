using Bll.Entity.Abstract;
using Bll.Entity.Models;
using Dal.EntityCore.Base;

namespace Bll.Entity.Base
{
    public class ArticleRepository : EntityBaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(Context context) : base(context)
        {
        }
    }
}
