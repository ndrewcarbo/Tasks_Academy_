namespace TaskFinale.Models
{
    public class Amministratore
    {
        public int AdminId { get; set; }

        public string Codice { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Passw { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
