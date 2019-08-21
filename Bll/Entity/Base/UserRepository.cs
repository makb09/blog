using Bll.Entity.Abstract;
using Bll.Entity.Models;
using Dal.EntityCore.Base;

namespace Bll.Entity.Base
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
