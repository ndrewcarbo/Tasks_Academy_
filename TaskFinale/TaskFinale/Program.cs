using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskFinale.Context;
using TaskFinale.Repos;
using TaskFinale.Services;

namespace TaskFinale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            //CONFIGUO CONTEXT 

            builder.Services.AddDbContext<FinaleContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DatabaseTest")
                )
            );

            //SCOPIZZIAMO REPOSITORY

            builder.Services.AddScoped<AmministratoreRepo>();
            builder.Services.AddScoped<UtenteRepo>();

            //SCOPIZZIAMO SERIVICES

            builder.Services.AddScoped<AmministratoreServices>();
            builder.Services.AddScoped<UtenteService>();

            //SESSIONE

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "taskfinale.com",
                    ValidAudience = "Sudditi",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("scrivi_Qualcosa_Ma_Cosa"))
                };
            });


            var app = builder.Build();

            //cors

            app.UseCors(builder =>
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
            );




            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
