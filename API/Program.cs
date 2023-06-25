using DAL;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .ConfigureMySQL(builder.Configuration)
                .ConfigureSwagger()
                .ConfigureControllers()
                .ConfigureApiExplorer()
                .ConfigureRepositoryWrapper()
                .ConfigureAppServices()
                .ConfigureMapperProfiles();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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