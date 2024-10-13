using System.ComponentModel.DataAnnotations.Schema;
using task_officina.Models;

namespace task_officina.Models
{
    [Table("Intervento")]
    public class Intervento
    {

        
        public int InterventoID { get; set; }
        public string Codice { get; set; } = null!;
        public string Targa { get; set; } = null!;
        public string Modello { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int Anno { get; set; }
        public decimal Prezzo { get; set; }

        public string? Stato { get; set; }
        public DateTime Data_start { get; set; }

        public int ClienteRIF { get; set; }
        
        //public Cliente? ClienteNavigation { get; set; }  


    }
}


//interventoID INT PRIMARY KEY IDENTITY(1,1),
//    codice VARCHAR(32) NOT NULL DEFAULT NEWID(),
//    targa VARCHAR(50) NOT NULL UNIQUE,
//    modello VARCHAR(50) NOT NULL,
//    marca VARCHAR(50) NOT NULL,
//    anno INT,
//    prezzo DECIMAL(10,2) CHECK (prezzo >= 0),
//    stato TEXT,
//    data_start DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
//    clienteRIF INT NOT NULL,
//    FOREIGN KEY (clienteRIF) REFERENCES Cliente(clienteID) ON DELETE CASCADE