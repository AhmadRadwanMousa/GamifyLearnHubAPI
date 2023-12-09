using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using GamifyLearnHub.Infra.Common;
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
