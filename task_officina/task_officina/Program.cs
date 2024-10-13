
using Microsoft.EntityFrameworkCore;
using task_officina.Models;
using task_officina.Repository;
using task_officina.Services;

namespace task_officina
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


            //CONTEXT

            builder.Services.AddDbContext<OfficinaContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
                );

            //REPOS

            builder.Services.AddScoped<ClienteRepos>();
            builder.Services.AddScoped<InterventoRepos>();


            //SERVIZI

            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<InterventoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
