using System.ComponentModel.DataAnnotations.Schema;

namespace task_ferramenta.Models
{

    [Table("Prodotto")]
    public class Prodotto
    {

        public int ProdottoId { get; set; }

        public string CodiceBarre { get; set; } = null!;

        public string Nome { get; set; } = null!;

        public string? Descrizione { get; set; }

        public decimal? Prezzo { get; set; }

        public int Quantita { get; set; }

        public int RepartoRif { get; set; }
    }
}
