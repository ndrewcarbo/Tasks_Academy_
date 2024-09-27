using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_biblio.Models.DAL;

namespace task_biblio.Models
{
    internal class Biblioteca
    {

        //------------------------- SINGLETON
        private static Biblioteca? instanza;

        private List<Prestito> elencoPrestiti = new List<Prestito>();

        public static Biblioteca GetInstance()
        {
            if (instanza == null)
                instanza = new Biblioteca();

            return instanza;
        }

        private Biblioteca () { }

        //-------------------------

        // inserisco prestito
        public bool InserisciPrestito(Prestito p)
        {
            bool risultato = false;

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Prestito (data_start,data_return) VALUES (@datst,@datret)";
                cmd.Parameters.AddWithValue("@datst", p.Data_st);
                cmd.Parameters.AddWithValue("@datret", p.Data_ret);

                try
                {
                    conn.Open();
                    int affRows = cmd.ExecuteNonQuery();

                    if (affRows > 0)
                        risultato = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }

                return risultato;
        }


        public void ControlloDisponibilita()
        {
            List<Libro> l = IDAOLibro.GetInstance().GetAll();

            var risultato = from libro in l
                            select libro.Disp;
            
        }

        public void PresainPrestito() { 
        }



        public void RecuperaUtentieLibri()
        {
            List<Utente> u = IDAOUtente.GetInstance().GetAll();
            List<Libro> l = IDAOLibro.GetInstance().GetAll();

            if (u is not null && l is not null)
            {
                elencoPrestiti.AddRange(u);
                elencoPrestiti.AddRange(l);
            }
        }

        public void StampaLibro()
        {
            RecuperaUtentieLibri();

            var risult = elencoPrestiti.Where(l => l.GetType() == typeof(Libro));

            foreach (var l in elencoPrestiti)
            {
                Console.WriteLine(l);
            }

            
        }
    }
}
