using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.BusinessLogic.BL_Services;
using MultiprojectWithDB.BusinessLogic.Services;
using MultiprojectWithDB.DataAccessLayer;
using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.DBRepositories;
using System.Reflection;

namespace MultiprojectWithDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MultiprojectDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
            });

            builder.Services.AddScoped<IUsersDBRepository, UsersDBRepository>();//repositoriai visada scoped, o ne trans
            builder.Services.AddScoped<INotesDBRepository, NotesDBRepository>();
            builder.Services.AddScoped<IUserService, UserService>();//del update, del viso pikto
            builder.Services.AddScoped<INoteService, NoteService>();//del update, kad nepasimestu dbcontext
            builder.Services.AddTransient<INoteMapper, NoteMapper>();
            builder.Services.AddTransient<IUserMapper, UserMapper>();
            builder.Services.AddTransient<IJwtService, JwtService>();




            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//musu auth schema bus kas nesa jwt, tas yra prisistates
               .AddJwtBearer(
               options =>
               {
                   var secretKey = builder.Configuration.GetSection("Jwt:Key").Value;
                   var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                       ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                       IssuerSigningKey = key
                   };
               });

            builder.Services.AddHttpContextAccessor();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // custom swagger comments
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Multilayer Project Test",
                    Description = "An ASP.NET Core Web API for managing Notes and Users",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);

            });

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
