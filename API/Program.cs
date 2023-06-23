using DAL;
using BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // подключение к БД
            var connectionStringUsers = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<UserDBContext>(options => options.UseMySQL(connectionStringUsers));
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UserDBContext>();

            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

            // секретные фразы, которые знает только сервер
            var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
            var issuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value;
            var audience = builder.Configuration.GetSection("JWTSettings:Audience").Value;
            var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = singingKey,
                    ValidateIssuerSigningKey = true
                };
            });


            // ограничиваем доступ к страницам
            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy("OnlyAdmin", policyBuilder => policyBuilder.RequireClaim("Role", "1"));
            });

            builder.Services
                .ConfigureMySQL(builder.Configuration)
                .ConfigureSwagger()
                .ConfigureControllers()
                .ConfigureApiExplorer()
                .ConfigureRepositoryWrapper();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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