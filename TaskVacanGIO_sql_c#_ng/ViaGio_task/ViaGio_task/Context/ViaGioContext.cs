using Microsoft.EntityFrameworkCore;
using ViaGio_task.Models;

namespace ViaGio_task.Context
{
    public class ViaGioContext : DbContext 
    {
        public ViaGioContext(DbContextOptions<ViaGioContext> options) : base(options) { }



            public DbSet<Pacchetto> Pacchetti { get; set; }
            public DbSet<Recensione> Recensioni { get; set; }
            public DbSet<Destinazione> Destinazioni { get; set; }
    }
}
