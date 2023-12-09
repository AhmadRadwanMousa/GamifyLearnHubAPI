using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authentication;
        public AuthenticationService(IAuthenticationRepository authentication)
        {
            _authentication=authentication; 
        }
        public string? Login(LoginCredentails loginDetails)
        {
         var existUser = _authentication.Login(loginDetails);
            if ( existUser==null)
            {
                return null;
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345"));
            var signCredintails = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
            var claimes = new List<Claim>
            {
                new Claim ("userName",existUser.Result.Username),
                new Claim ("roleId",existUser.Result.Roleid.ToString()),
                new Claim ("userId",existUser.Result.Userid.ToString())

            };
            var tokenOptions = new JwtSecurityToken(
                claims: claimes,
                expires: DateTime.Now.AddHours(3),
                signingCredentials:signCredintails
                ); ;
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
