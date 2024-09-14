using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1309.classes
{
    internal class Studente
    {
        private static int contatore_Stud = 0;

        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public double Voto { get; set; }

        public Studente(string varNome, string varCognome , double voto)
        {
            Nome = varNome;
            Cognome = varCognome;
            Voto = voto;
        }

        public Studente()
        {
            contatore_Stud++;
        }


        


        public virtual void Iscrizione(Studente stud) 
        { 
           
        }

        public override string ToString()
        {
            return $"[Studente] {Nome} {Cognome} {Voto}";
        }

        


        public static int getContatore()
        {
            return contatore_Stud;
        }
    }
}
