using Microsoft.EntityFrameworkCore;

namespace task_officina.Models
{
    public class OfficinaContext : DbContext
    {
        public OfficinaContext(DbContextOptions<OfficinaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Intervento> Interventi { get; set; }
    }
}
