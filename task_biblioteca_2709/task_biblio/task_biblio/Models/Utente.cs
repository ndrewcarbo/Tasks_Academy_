using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_biblio.Models
{
    internal class Utente : Prestito
    {

        public string? Nome { get; set; }
        public string? Cognome { get; set; }

        public string? Email { get; set; }

        public override string ToString()
        {
            return $"[Utente] {Code} {Nome} {Cognome} {Email}";
        }
    }
}
