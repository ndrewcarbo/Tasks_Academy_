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

            // Aggiungi servizi al contenitore.
            builder.Services.AddControllersWithViews();

            // CONFIGURO CONTEXT 
            builder.Services.AddDbContext<FinaleContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
            );

            // SCOPIZZIAMO REPOSITORY
            builder.Services.AddScoped<AmministratoreRepo>();
            builder.Services.AddScoped<UtenteRepo>();

            // SCOPIZZIAMO SERVICES
            builder.Services.AddScoped<AmministratoreServices>();
            builder.Services.AddScoped<UtenteService>();
            builder.Services.AddScoped<UtenteApiService>();

            // SESSIONE
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
                    ValidIssuer = "http://localhost:5292",
                    ValidAudience = "Sudditi",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("giovanni_genio_giovanni_genio_giovanni_genio_giovanni_genio_giovanni_genio"))
                };
            });

            var app = builder.Build();


            // Configura la pipeline delle richieste HTTP.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

           // app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();


            app.UseCors(builder =>
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}"
            );

            app.Run();
        }
    }
}
