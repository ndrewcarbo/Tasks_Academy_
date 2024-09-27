using task_biblio.Models;
using task_biblio.Models.DAL;

namespace task_biblio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool insAbi = true;

            while (insAbi)
            {

                Console.WriteLine("Ciao! Benvenuto nella Biblioteca \n" +
                    "I per inserire \n" +
                    "S per Stampare \n" +
                    "C per Cercare un libro da prendere in prestito"
                    );
                string? inputUT = Console.ReadLine();

                if (inputUT is null)
                {
                    Console.WriteLine("COMANDO ERRATO");
                    insAbi = false;
                }
                else
                {
                    switch (inputUT)
                    {
                    
                        case "I":
                            Console.Write("Cosa vuoi Inserire? \n");
                            Console.WriteLine("U PER UTENTE \n" +
                                "L PER LIBRO \n");
                            string? ins = Console.ReadLine();
                            if (ins is null)
                                Console.WriteLine("COMANDO ERRATO");
                            else
                            {

                                switch (ins)
                                {
                                    case "U":
                                        Console.Write("Dammi il nome: ");
                                        string? inNome = Console.ReadLine();
                                        Console.Write("Dammi il cognome: ");
                                        string? inCogn = Console.ReadLine();
                                        Console.Write("Dimmi la tua email: ");
                                        string? inEma = Console.ReadLine();
                                        break;
                                    case "L":
                                        Console.Write("Dammi il Titolo: ");
                                        string? inTit = Console.ReadLine();
                                        Console.Write("Dammi l'anno: ");
                                        string? inAns = Console.ReadLine();
                                        if (Convert.ToInt32(inAns) > 2024)
                                            Console.WriteLine("VIVI NEL FUTURO? LIBRO NON INSERITO.");
                                        else
                                            Console.WriteLine("INSERITO");
                                        break;
                                    default:
                                        Console.WriteLine("Comando non riconosciuto");
                                        break;
                                }



                            }
                            break;

                        case "S":
                            Console.Write("Cosa vuoi Stampare? \n");
                            Console.WriteLine("L PER Libri \n" +
                                "U PER Utenti \n" +
                                "P PER PRESTATI");
                            string? inptS = Console.ReadLine();
                            if (inptS is null)
                                Console.WriteLine("COMANDO ERRATO");
                            else
                            {
                                switch (inptS)
                                {
                                    case "L":
                                        Console.WriteLine("ECCO LA LISTA DEI LIBRI");
                                        Biblioteca.GetInstance().StampaLibro();
                                        break;
                                    case "U":
                                        Console.WriteLine("STAMPA UTENTI");
                                        break;
                                    case "P":
                                        Console.WriteLine("STAMPA TUTTO");
                                        Biblioteca.GetInstance().StampaLibro();
                                        break;
                                }
                            }
                            break;
                            case "C":
                            Console.WriteLine("CERCA");
                            break;
                            default:
                            Console.WriteLine("COMANDO NON RICONOSCIUTOO");
                            break;
                    }
                }
            }
        }
    }
}