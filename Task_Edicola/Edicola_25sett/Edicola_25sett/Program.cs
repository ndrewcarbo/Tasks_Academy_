using Edicola_25sett.Models;

namespace Edicola_25sett
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            * Creare un sistema di gestione edicola.
            * In un'edicola sono presenti riviste e giocattoli.
            * Entrambi sono caratterizzati da un codice univoco (assegnato automaticamente all'inserimento nel DB) ed il prezzo.
            * 
            * Un gicattolo è caratterizzato almeno da:
            * - materiale
            * - età minima
            * 
            * La rivista è caratterizzata
            * - titolo
            * - casa editrice
            * 
            * Creare un sistema che si occupi di:
            * 1. Inserire riviste o giocattoli
            * 2. Stampare tutti i prodotti
            * 3. Stampare solo le riviste (con LINQ)
            * 4. Stampare solo i giocattoli (con LINQ)
            * 5. Conta tutti gli elementi (con LINQ)
            * 5. Cercare un elemento e stamparne i dettagli tramite il codice univoco.
            */

            List<Rivista> lista = new List<Rivista>();



            Rivista roolingStones = new Rivista()
            {
                Id = 11,
                Codice = 1234523456,
                Titolo = "Rolling Stones",
                Prezzo = 12,
                Casaedit = "RS"
            };
            Rivista topolino = new Rivista()
            {
                Id = 12,
                Codice = 12345236,
                Titolo = "topolino 2",
                Prezzo = 12,
                Casaedit = "tp"
            };

            lista.Add(roolingStones);
            lista.Add(topolino);


            //tutte le riviste
            //var risultato = from rivista in lista 
                            select rivista;

            var risultato = from gioco in 
        }


    }
}
