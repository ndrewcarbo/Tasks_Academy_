
using Microsoft.EntityFrameworkCore;
using task_ferramenta.Models;
using task_ferramenta.Repos;
using task_ferramenta.Services;

namespace task_ferramenta
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

            //configuro il ctx 

            builder.Services.AddDbContext<FerramentaCtx>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
               );

            builder.Services.AddScoped<ProdottoRepo>();
            builder.Services.AddScoped<RepartoRepo>();


            //=======================NOTABENEEE================================================
            //  RICORDATI I SERVIZI!!!! ALLO SCOPE

            builder.Services.AddScoped<ProdottoService>();
            builder.Services.AddScoped<RepartoService>();


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
