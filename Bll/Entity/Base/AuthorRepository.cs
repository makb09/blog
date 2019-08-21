using Bll.Entity.Abstract;
using Bll.Entity.Models;
using Dal.EntityCore.Base;

namespace Bll.Entity.Base
{
    public class AuthorRepository : EntityBaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(Context context) : base(context)
        {
        }
    }
}
