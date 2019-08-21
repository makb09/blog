using Bll.Entity.Abstract;
using Bll.Entity.Models;
using Bll.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Blog.Dto.Authentication;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IUserRepository userRepository;
        IAuthenticationRepository authenticationRepository;
        IConfiguration config;

        public AuthenticationController(IUserRepository userRepository, IAuthenticationRepository authenticationRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.authenticationRepository = authenticationRepository;
            this.config = configuration;
        }

        [Route("login"), HttpPost]
        public IActionResult Login([FromBody]Login login)
        {
            User user = userRepository.GetSingle(a => a.EmailAddress == login.EmailAddress && a.Password == Crypto.EncryptoMD5(login.Password), b => b.UserRole);
            if (user != null)
            {
                return Ok(new LoginResult()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    EmailAddress = user.EmailAddress,
                    Token = authenticationRepository.BuildToken(config, user.Id, user.UserRole.Code, user.UserRoleId)
                });
            }

            return BadRequest("Eposta veya parola eşleşmedi.");
        }
    }
}