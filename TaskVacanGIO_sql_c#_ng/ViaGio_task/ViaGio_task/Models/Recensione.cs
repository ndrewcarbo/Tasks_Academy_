using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ViaGio_task.Models
{
    [Table("Recensione")]
    public class Recensione
    {
        [Key]
        public int RecensioneID { get; set; }

        public string Codice { get; set; } = null!;

        public string NomeUtente { get; set; } = null!;

        public int Voto { get; set; }

        public string Commento { get; set; } = null!;

        //[Column]
        //[Column(TypeName = "date")]
        public DateOnly? Data_Rec { get; set; }

        public int pacchettoRIF { get; set; }

        
        
        //public virtual Pacchetto PacchettoRifNavigation { get; set; } = null!;
    }
}
