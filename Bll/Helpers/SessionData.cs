using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Bll.Helpers
{
    public static class SessionData
    {
        public const string userid = "usid";

        public static int GetUserId(HttpContext context) => int.TryParse(context.User.Claims.Where(x => x.Type == userid).FirstOrDefault()?.Value, out int id) ? id : default(int);

        public static int GetUserRoleId(HttpContext context) => int.TryParse(context.User.Claims.Where(x => x.Type == "roleId").FirstOrDefault()?.Value, out int id) ? id : default(int);

        public static string GetUserRole(HttpContext context) => context.User.Claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").FirstOrDefault()?.Value;

        public static short GetTesisId(HttpContext context) => short.TryParse(context.Request.Headers["X-TesisId"], out short id) ? id : default(short);

        public static int GetSirketId(HttpContext context) => int.TryParse(context.Request.Headers["X-SirketId"], out int id) ? id : default(int);
    }

}
