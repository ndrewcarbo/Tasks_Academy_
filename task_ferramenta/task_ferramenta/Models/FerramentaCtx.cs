using Microsoft.EntityFrameworkCore;

namespace task_ferramenta.Models
{
    public class FerramentaCtx : DbContext
    {

        // COSTR

        public FerramentaCtx(DbContextOptions<FerramentaCtx> options) : base(options) { }
        

        public DbSet<Prodotto> Prodottos { get; set; }
        public DbSet<Reparto> Repartos { get; set; }

    }
}
