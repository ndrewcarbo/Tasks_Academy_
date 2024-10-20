
using Microsoft.EntityFrameworkCore;
using ViaGio_task.Context;
using ViaGio_task.Repositories;
using ViaGio_task.Services;

namespace ViaGio_task
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

            builder.Services.AddDbContext<ViaGioContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
               );


            builder.Services.AddScoped<PacchettoRepos>();
            builder.Services.AddScoped<DestinazioneRepos>();
            builder.Services.AddScoped<RecensioneRepos>();

            builder.Services.AddScoped<PacchettoServices>();
            builder.Services.AddScoped<DestinazioneServices>();
            builder.Services.AddScoped<RecensioniServices>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

            app.Run();
        }
    }
}
