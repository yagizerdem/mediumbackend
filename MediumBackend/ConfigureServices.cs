using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models.Entity;
using Repository.Interface;
using Repository.RepositoryClass;
using Repository.UnitOfWork;
using Services.Interface;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Services.ServiceClass;

namespace MediumBackend
{
    public class ConfigureServices
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("msSqlDatabase")));


            //AppSettings konfigurasyonu
            services.Configure<JWT>(configuration.GetSection("JWT"));

            //DI User Service from .net identity
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            // custom services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ILikeService, LikeService>();

            services.AddControllers()
        .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);




            // JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin() // Replace with your frontend URL
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });



            // repository
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ILikeRepostiory, LikeRepository>();

            // unit of work 
            services.AddScoped<IUnitOfWork, UnitOfWork>();




            // automapper
            IMapper autoMapper = AutoMapperConfiguration.Config();
            services.AddSingleton(autoMapper);
        }
    }
}
