using Bll.Entity.Abstract;
using Bll.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bll.Entity.Base
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public string BuildToken(IConfiguration _config, int id, string rolKod, int rolId)
        {
            Claim[] claims = new[] {
                    new Claim("Id", id.ToString()),
                    new Claim("RolId", rolId.ToString()),
                    new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", rolKod),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
