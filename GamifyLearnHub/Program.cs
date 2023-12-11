using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GamifyLearnHub.Infra.Repositroy;
using GamifyLearnHub.Infra.Service;
using GamifyLearnHub.Infra.Repository;


using GamifyLearnHup.Infra.Repository;
using GamifyLearnHup.Infra.Service;



namespace GamifyLearnHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IDbContext, DbContext>();

            builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
            builder.Services.AddScoped<ICertificationService, CertificationService>();

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
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<IUserSectionRepository, UserSectionRepository>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();


            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<IUserSectionService, UserSectionService>();
            builder.Services.AddScoped<IPlanRepository, PlanRepository>();
            builder.Services.AddScoped<IEducationalPeriodRepository, EducationalPeriodRepository>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<IEducationalPeriodService, EducationalPeriodService>();
            builder.Services.AddScoped<IUserService, UserService>();    
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IExamService, ExamService>();    
            builder.Services.AddScoped<IQuestionService, QuestionService>(); 
            builder.Services.AddScoped<IQuestionOptionService, QuestionOptionService>(); 
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
