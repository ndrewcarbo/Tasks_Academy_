using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1309.classes
{
    internal class Academy
    {
        private static int contatore_Iscrizioni = 0;
        public string? Nome { get; set; }
        public string? Indirizzo { get; set; }

        public List<Studente>? Elenco { get; set; } = null;




        public void Settembre(Studente stud)
        {
            if (Elenco is null)
            {
                 Elenco = new List<Studente>();
            }
            else
            {
                Elenco.Add(stud);
            }
        }


        public void Iscrizione(Studente stud)
        {
            Elenco?.Add(stud);
        }
    }
}
