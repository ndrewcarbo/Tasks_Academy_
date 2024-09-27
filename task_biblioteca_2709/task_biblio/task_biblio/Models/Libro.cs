using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_biblio.Models
{
    internal class Libro : Prestito
    {
        public string Titolo { get; set; } = null!;
        public string? Anno_pub { get; set; } = null!;

        public bool Disp { get; set; } 


        public override string ToString()
        {
            return $"[Libro]: {Code} {Titolo} {Anno_pub} {Disp}";
        }
    }
}
