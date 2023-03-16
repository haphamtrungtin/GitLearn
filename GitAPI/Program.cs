using System.Text.Json.Serialization;
using AutoMapper;
using GitAPI.Automapper;
using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.Repositories.Repository;
using GitLearn.DAL.UnitOfWork;
using GitLearn.Data;
using GitLearn.Services.Interface;
using GitLearn.Services.Service;
using GitSimulator.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace GitAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<GitContext>(options => 
                                                      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<ITeamService, TeamService>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddControllers()
           .AddJsonOptions(o => o.JsonSerializerOptions
               .ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddSingleton(mapper);

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