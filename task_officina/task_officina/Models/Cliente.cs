using System.ComponentModel.DataAnnotations.Schema;
using task_officina.Models;

namespace task_officina.Models
{

    [Table("Cliente")]
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Codice { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string? Email { get; set; }
        public string? Indirizzo { get; set; }
        public string? Telefono { get; set; }

        //public List<Intervento> Interventi { get; set; } = new List<Intervento>();
    }
}


//clienteID INT PRIMARY KEY IDENTITY(1,1),
//    codice VARCHAR(32) NOT NULL DEFAULT NEWID(),
//    nome VARCHAR(250) NOT NULL,
//    cognome VARCHAR(250) NOT NULL,
//    email VARCHAR(250),
//    indirizzo VARCHAR(250),
//    telefono VARCHAR(250)