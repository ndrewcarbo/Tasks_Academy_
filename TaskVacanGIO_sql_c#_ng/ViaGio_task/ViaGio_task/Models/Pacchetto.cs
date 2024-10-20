using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViaGio_task.Models
{
    [Table("Pacchetto")]
    public class Pacchetto
    {
        [Key]
        public int PacchettoID { get; set; }

        public string Nome { get; set; } = null!;

        public string Codice { get; set; } = null!;

        public string? Durata { get; set; }

        public decimal Prezzo { get; set; }

        [Column]
        public DateOnly Data_Iniz { get; set; }

        [Column]
        public DateOnly Data_Fine { get; set; }

        //public virtual ICollection<DestPacc> DestPaccs { get; set; } = new List<DestPacc>();

        //public virtual ICollection<Recensione> Recensiones { get; set; } = new List<Recensione>();
    }
}
