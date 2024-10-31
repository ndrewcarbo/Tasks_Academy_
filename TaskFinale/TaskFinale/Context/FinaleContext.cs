using Microsoft.EntityFrameworkCore;
using TaskFinale.Models;

namespace TaskFinale.Context
{
    public class FinaleContext : DbContext
    {
        public FinaleContext(DbContextOptions<FinaleContext> options) : base(options) { }


        public DbSet<Utente> Utentes { get; set; }
        public DbSet<Amministratore> Adimns { get; set; }
    }
}
