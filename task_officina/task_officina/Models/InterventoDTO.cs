namespace task_officina.Models
{
    public class InterventoDTO
    {
        public string Cod { get; set; } = null!;
        public string Tar { get; set; } = null!;
        public string Mod { get; set; } = null!;
        public string Mar { get; set; } = null!;
        public int Ann { get; set; }
        public decimal Pre { get; set; }

        public string? Sta { get; set; }
        public DateTime Data_st { get; set; }
    }
}
