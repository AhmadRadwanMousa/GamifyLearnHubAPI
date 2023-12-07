using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Common;
using GamifyLearnHub.Infra.Repositroy;
using GamifyLearnHub.Infra.Service;

namespace GamifyLearnHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IDbContext, DbContext>();
            builder.Services.AddScoped<IBadgeActivityRepository, BadgeActivityRepository>();
            builder.Services.AddScoped<IBadgeActivityService, BadgeActivityService>();
            builder.Services.AddScoped<IProgramRepository, ProgramRepository>(); 
            builder.Services.AddScoped<IProgramService, ProgramService>(); 


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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
