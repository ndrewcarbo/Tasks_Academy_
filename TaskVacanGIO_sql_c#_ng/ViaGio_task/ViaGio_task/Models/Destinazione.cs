using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViaGio_task.Models
{
    [Table("Destinazione")]
    public class Destinazione
    {
        [Key]
        public int DestinazioneID { get; set; }

        public string Nome { get; set; } = null!;

        public string? Descrizione { get; set; }

        public string Paese { get; set; } = null!;

        public string Immagine { get; set; } = null!;

        //public virtual ICollection<DestPacc> DestPaccs { get; set; } = new List<DestPacc>();
    }
}
