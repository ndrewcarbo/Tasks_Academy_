using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edicola_25sett.Models
{
    internal class Rivista
    {

        public int Id { get; set; }
        public int Codice { get; set; }
        public string? Titolo { get; set; }
        public float Prezzo { get; set; }

        public string? Casaedit { get; set; }


        public override string ToString()
        {
            return $"[Rivista] {Id} {Codice} {Titolo} {Prezzo} {Casaedit}";
        }
    }
}
