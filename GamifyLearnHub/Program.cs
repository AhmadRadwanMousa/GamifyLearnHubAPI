using GamifyLearnHub.Core.Common;

using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GamifyLearnHub.Infra.Repositroy;
using GamifyLearnHub.Infra.Service;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Repositroy;
using GamifyLearnHup.Infra.Repository;
using GamifyLearnHup.Infra.Service;
using System.ComponentModel.Design;


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
            builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();  
            builder.Services.AddScoped<IBadgeActivityRepository, BadgeActivityRepository>();
            builder.Services.AddScoped<IBadgeActivityService, BadgeActivityService>();
            builder.Services.AddScoped<IProgramRepository, ProgramRepository>(); 
            builder.Services.AddScoped<IProgramService, ProgramService>(); 
            builder.Services.AddScoped<IPointsActivityRepository, PointsActivityRepository>(); 
            builder.Services.AddScoped<IPointsActivityService, PointsActivityService>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseSequenceRepository, CourseSequenceRepository>();
            builder.Services.AddScoped<ICourseSequenceService, CourseSequenceService>();

            builder.Services.AddScoped<IUserService, UserService>();    
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();    
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
 
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<IUserSectionRepository, UserSectionRepository>();


            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<IUserSectionService, UserSectionService>();



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
