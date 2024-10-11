using System.ComponentModel.DataAnnotations.Schema;

namespace task_ferramenta.Models
{

    [Table("Reparto")]
    public class Reparto
    {
        public int RepartoId { get; set; }

        public string RepartoCod { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string Fila { get; set; } = null!;

        public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();

    }
}
