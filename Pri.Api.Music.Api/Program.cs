using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pri.Api.Music.Core.Entities;
using Pri.Api.Music.Core.Interfaces.Repositories;
using Pri.Api.Music.Core.Interfaces.Services;
using Pri.Api.Music.Core.Services;
using Pri.Api.Music.Infrastructure.Repositories;
using Pri.CleanArchitecture.Music.Core.Interfaces.Repositories;
using Pri.CleanArchitecture.Music.Core.Interfaces.Services;
using Pri.CleanArchitecture.Music.Core.Services;
using Pri.CleanArchitecture.Music.Infrastructure.Data;
using Pri.CleanArchitecture.Music.Infrastructure.Repositories;
using System.Text;

namespace Pri.Api.Music.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Add database service
            builder.Services.AddDbContext<ApplicationDbContext>
                (options => options
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultDb")));
            //register identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //ONLY FOR TESTING PURPOSES!!!!
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            //add jwt authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = builder.Configuration["JWTConfiguration:Audience"],
                    ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SigninKey"]))
                };
            });
            // Add services to the container.
            builder.Services.AddScoped<IRecordRepository, RecordRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            builder.Services.AddScoped<IRecordService, RecordService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IArtistService, ArtistService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
