using Task_2_1309.classes;

namespace Task_2_1309
{
    internal class Program
    {
        static void Main(string[] args)
        {



            bool inserimento = true;

            while (inserimento)
            {
                {
                    Console.WriteLine("BENVENUTO NELL' UNIVERSITA: \n" +
                                    "Premi I per iscriverti");
                    string? inputStud = Console.ReadLine();
                    if (inputStud is null)
                        Console.WriteLine("Specifica un comando");
                    else
                    {
                        switch (inputStud)
                        {
                            case "I":
                                Studente studuno = new Studente();
                                break;

                        }




                    }







                }
            }
        }
    }
}
