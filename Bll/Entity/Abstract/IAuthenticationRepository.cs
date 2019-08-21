using Microsoft.Extensions.Configuration;

namespace Bll.Entity.Abstract
{
    public interface IAuthenticationRepository
    {
        string BuildToken(IConfiguration _config, int id, string Rol, int RolId);
    }
}
