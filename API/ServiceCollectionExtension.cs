using DAL;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<SightseeingdbContext>(options
                 => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
