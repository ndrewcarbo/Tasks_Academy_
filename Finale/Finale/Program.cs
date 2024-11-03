using Finale.Ctx;
using Finale.Repos;
using Finale.Services;
using Microsoft.EntityFrameworkCore;

namespace Finale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //CTX
            builder.Services.AddDbContext<FinaleContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
            );

            //SCOPIZZIAMO

            builder.Services.AddScoped<AmministratoreRepo>();
            builder.Services.AddScoped<UtenteRepo>();
            builder.Services.AddScoped<UtenteServices>();
            builder.Services.AddScoped<AdminServices>();
            builder.Services.AddScoped<UtenteApiService>();

            //SESSIONE

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //ses
            app.UseSession();
            //CORS
            app.UseCors(builder =>
           builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
           );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
