using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Common;
using GamifyLearnHub.Infra.Repository;
using GamifyLearnHub.Infra.Service;

namespace GamifyLearnHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IDbContext, DbContext>();


            builder.Services.AddControllers();
          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<IPlanRepository, PlanRepository>();
			builder.Services.AddScoped<IEducationalPeriodRepository, EducationalPeriodRepository>();
			builder.Services.AddScoped<IPlanService, PlanService>();
			builder.Services.AddScoped<IEducationalPeriodService, EducationalPeriodService>();
			var app = builder.Build();

           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
