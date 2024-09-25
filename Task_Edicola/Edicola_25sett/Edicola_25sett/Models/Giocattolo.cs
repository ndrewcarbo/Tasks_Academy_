using Edicola_25sett.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edicola_25sett.Models
{
    internal class Giocattolo 
    {
        public int Id { get; set; }
        public int Codice { get; set; }
        public string? Nome { get; set; }
        public string? Materiale { get; set; }
        public float Prezzo { get; set; }

        public int Eta { get; set; }

       
        public override string ToString()
        {
            return $"[GIOCATTOLO] {Id} {Codice} {Nome} {Materiale} {Prezzo} {Eta}";
        }




    }
}


