namespace Calcolatrice_task_13_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static double Somma(double numUno, double numDue)
            {
                return numUno + numDue;
            }

            static double Sottrazione(double numUno, double numDue)
            {
                return numUno - numDue;
            }

            static double Divisione(double numUno, double numDue)
            {
                return numUno / numDue;
            }

            static double Moltiplicazione(double numUno, double numDue)
            {
                return numUno * numDue;
            }

            static double Potenza(double numUno)
            {
                return numUno * numUno;
            }





            bool inserimento = true;

            while (inserimento)
            {

                Console.WriteLine("CIAO QUESTA è LA CALCOLATRICE FATTA MALE \n" +
                    "Premi Q per QUITTARE");


                try
                {

                Console.WriteLine("INSERISCI UN NUMERO");
                double numUno = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("INSERISCI UN OPERATORE : \n" +
                    "\" - + per Sommare , - per Sottrarre , / per dividere, e * per Moltiplicare\"");
                string? operazione = Console.ReadLine();

                Console.WriteLine("INSERISCI UN NUMERO");
                double numDue = Convert.ToDouble(Console.ReadLine());





                    
                        if (operazione is not null && operazione.Length == 1)
                        {


                            switch (operazione)
                            {
                                case "+":
                                    Console.WriteLine(Somma(numUno, numDue));
                                    break;
                                case "-":
                                    Console.WriteLine(Sottrazione(numUno, numDue));
                                    break;
                                case "/":
                                    Console.WriteLine(Divisione(numUno, numDue));
                                    break;
                                case "*":
                                    Console.WriteLine(Moltiplicazione(numUno, numDue));
                                    break;
                                case "P":
                                Console.WriteLine(Potenza(numUno));
                                    break;  
                                case "Q":
                                    inserimento = false;
                                    Console.WriteLine("Arrivederci questa era la calcolatrice fatta male");
                                    break;
                                default:
                                    Console.WriteLine("ERRORE Scegli un segno");
                                    break;

                            }
                        }
                 

                }
                catch (Exception fe)
                {
                    Console.WriteLine("Errore INPUT");
                
                }


            }

        }
    }
}
