namespace ViaGio_task.Models
{
    public class DestPacc
    {
        public int DesPacID { get; set; }
        public int DestinazioneRIF { get; set; }
        public int PacchettoRIF { get; set; }

        //public virtual Destinazione DestinazioneRifNavigation { get; set; } = null!;

        //public virtual Pacchetto PacchettoRifNavigation { get; set; } = null!;
    }
}
