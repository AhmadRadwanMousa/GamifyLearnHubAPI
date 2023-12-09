using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Common;
using GamifyLearnHub.Infra.Repositroy;
using GamifyLearnHub.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GamifyLearnHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<IDbContext, DbContext>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();  


            builder.Services.AddScoped<IUserService, UserService>();    
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddAuthentication((opt) => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer((options) =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345"))
                };
            });
 
            builder.Services.AddControllers();
          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        

       
            var app = builder.Build();

           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
