using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Bcpg;
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

        public async Task<int> IsUserNameExist(string userName)
        {
            int isExist = await _authentication.IsUserNameExist(userName);  
            if (isExist != 1)
            {
                return 0;
            }
            string otp = "";
            Random random = new Random();   
            for (int i = 0; i < 5; i++)
            {
                int digit = random.Next(0, 10);
                otp += digit.ToString();
            }
            return Convert.ToInt32(otp);
        }

        public async Task<string>? Login(LoginCredentails loginDetails)
        {
         var existUser = await _authentication.Login(loginDetails);
            if ( existUser==null)
            {
                return null;
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345"));
            var signCredintails = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256);
            var claimes = new List<Claim>
            {
                new Claim ("userName",existUser.Username),
                new Claim ("roleId",existUser.Roleid.ToString()),
                new Claim ("userId",existUser.Userid.ToString()),
                new Claim ("isAccepted",existUser.Isaccepted.ToString())
            };
            var tokenOptions = new JwtSecurityToken(
                claims: claimes,
                expires: DateTime.Now.AddHours(3),
                signingCredentials:signCredintails
                ); ;
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }

        public async Task<int> ResetPassword(LoginCredentails loginDetails)
        {
           return await _authentication.ResetPassword(loginDetails);    
        }
    }
}
