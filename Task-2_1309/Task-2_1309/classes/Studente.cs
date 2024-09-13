using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1309.classes
{
    internal class Studente
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public double Voto { get; set; }


        public Studente() { }

        public Studente(string varNome, string varCognome , double voto)
        {
            Nome = varNome;
            Cognome = varCognome;
            Voto = voto;
        }



        public virtual void Iscrizione() 
        { 
           

        }

        public override string ToString()
        {
            return $"[Studente] {Nome} {Cognome} {Voto}";
        }
    }
}
