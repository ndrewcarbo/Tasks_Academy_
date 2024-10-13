namespace task_officina.Models
{
    public class ClienteDTO
    {
        public string Cod { get; set; } = null!;
        public string Nom { get; set; } = null!;
        public string Cog { get; set; } = null!;
        public string? Ema { get; set; }
        public string? Ind { get; set; }
        public string? Tel { get; set; }
    }
}
