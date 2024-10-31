using System.Text.Json.Serialization;

namespace TaskFinale.Models
{
    public class Login
    {
        public string? Username { get; set; }
        public string? Password { get; set; }

        [JsonIgnore]
        public string? UserType { get; set; }
    }
}
