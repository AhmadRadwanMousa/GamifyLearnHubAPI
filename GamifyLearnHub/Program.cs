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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<IDbContext, DbContext>();

            builder.Services.AddScoped<ICertificationRepository, CertificationRepository>();
            builder.Services.AddScoped<ICertificationService, CertificationService>();

            builder.Services.AddScoped<IExamLearnerRepository, ExamLearnerRepository>();
            builder.Services.AddScoped<IExamLearnerService, ExamLearnerService>();


            builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            builder.Services.AddScoped<ITestimonialService, TestimonialService>();


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
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<IUserSectionRepository, UserSectionRepository>();
            
            builder.Services.AddScoped<ICourseSectionRepository, CourseSectionRepository>();
            builder.Services.AddScoped<ILectureRepository, LectureRepository>();
            builder.Services.AddScoped<ISectionAnnouncementRepository, SectionAnnouncementRepository>();
            builder.Services.AddScoped<IUserProgressRepository, UserProgressRepository>();
            builder.Services.AddScoped<IAttendenceRepository, AttendenceRepository>();
            builder.Services.AddScoped<IAttendenceDetailRepository, AttendenceDetailRepository>();
            


            builder.Services.AddScoped<ILectureService, LectureService>();
            builder.Services.AddScoped<ICourseSectionService, CourseSectionService>();
            builder.Services.AddScoped<ISectionAnnouncementService, SectionAnnouncementService>();
            builder.Services.AddScoped<IUserProgressService, UserProgressService>();

            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

            builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            builder.Services.AddScoped<IAssignmentSolutionRepository, AssignmentSolutionRepository>();
            
            builder.Services.AddScoped<IAssignmentSolutionService, AssignmentSolutionService>();
            builder.Services.AddScoped<IAssignmentService, AssignmentService>();    

            builder.Services.AddScoped<IAssignmentSolutionDetailsRepository, AssignmentSolutionDetailsRepository>();    
            builder.Services.AddScoped<IAssignmentSolutionDetailsService, AssignmentSolutionDetailsService>();  
            builder.Services.AddScoped<ICouponRepository, CouponRepository>();
            builder.Services.AddScoped<ICouponService, CouponService>();
            builder.Services.AddScoped<IUserCouponRepository, UserCouponRepository>();
            builder.Services.AddScoped<IUserCouponService, UserCouponService>();
            builder.Services.AddScoped<IUserSectionService, UserSectionService>();
            builder.Services.AddScoped<IPlanRepository, PlanRepository>();
            builder.Services.AddScoped<IEducationalPeriodRepository, EducationalPeriodRepository>();
            builder.Services.AddScoped<ICourseSequenceService, CourseSequenceService>();
            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<IEducationalPeriodService, EducationalPeriodService>();
            builder.Services.AddScoped<IUserService, UserService>();    
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IExamService, ExamService>();    
            builder.Services.AddScoped<IQuestionService, QuestionService>(); 
            builder.Services.AddScoped<IQuestionOptionService, QuestionOptionService>();
            builder.Services.AddScoped<IAttendenceService, AttendenceService>();
            builder.Services.AddScoped<IAttendenceDetailService, AttendenceDetailService>();
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

            app.UseCors("policy");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
