using Finale.Models;
using Microsoft.EntityFrameworkCore;

namespace Finale.Ctx
{
    public class FinaleContext : DbContext
    {
        public FinaleContext(DbContextOptions<FinaleContext> options) : base(options) { }


        public DbSet<Utente> Utente { get; set; }
        public DbSet<Amministratore> Amministratore { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amministratore>()
                .HasKey(ak => ak.AdminId);

            

        }
    }
}
