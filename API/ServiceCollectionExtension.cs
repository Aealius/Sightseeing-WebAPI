using BLL.Services.Contracts;
using BLL.Services.Implementation;
using DAL;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureApiExplorer (this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            return services;
        }

        public static IServiceCollection ConfigureMySQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SightseeingdbContext>(options
                 => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sightseeing API",
                    Description = "An ASP.NET Core Web API for sights"
                });
            });

            return services;
        }

        public static IServiceCollection ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        public static IServiceCollection ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork,UnitOfWork> ();

            return services;
        }

        public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IGuideService, GuideService>();
            services.AddScoped<IGuideTourService, GuideTourService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISightService, SightService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<ITourSightService, TourSightService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection ConfigureMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
