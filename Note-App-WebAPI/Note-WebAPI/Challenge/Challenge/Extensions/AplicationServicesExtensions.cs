using Challenge.DataAccess;
using Challenge.DataAccess.Implementations;
using Challenge.DataAccess.Interfaces;
using Challenge.Domain.Entities;
using Challenge.Services.Implementations;
using Challenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Extensions
{
    public static class AplicationServicesExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services,
            IConfiguration config)
        {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<INoteRepository<Note>, NoteRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INoteService, NoteService>();           

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });


            return services;
        }
    }
}
