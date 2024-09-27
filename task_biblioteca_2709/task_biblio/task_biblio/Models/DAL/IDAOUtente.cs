using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_biblio.Models.DAL
{
    internal class IDAOUtente : IDAOLettura<Utente>, IDAOScrittura<Utente>
    {

        private static IDAOUtente? instanza;

        public static IDAOUtente GetInstance()
        {
            if (instanza is null)
                instanza = new IDAOUtente();

            return instanza;
        }

        private IDAOUtente() { }

        public bool Delete(int id)
        {
            bool risulstato = false;
            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Utente WHERE utenteID = @varId ";

                cmd.Parameters.AddWithValue("@varId", 1);


                try
                {
                    conn.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                    {
                        Console.WriteLine("Utente eliminato");
                    }
                    else
                    {
                        Console.WriteLine("ERRORE");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                conn.Close();
                }
                return risulstato;
            }


        

        public List<Utente> GetAll() 
        {

            List<Utente> risultato = new List<Utente>();

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT utenteID,codice,nome,cognome,email FROM Utente";

                try
                {
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Utente temporaneo = new Utente()
                        {
                            Id = read.GetInt32(0),
                            Code = read.GetString(1),
                            Nome = read.GetString(2),
                            Cognome = read.GetString(4),
                            Email = read.GetString(5),
                        };

                        risultato.Add(temporaneo);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return risultato;
            }
        }

        public Utente GetByCodice(string cod)
        {
            throw new NotImplementedException();
        }

        public Utente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Utente t)
        {
            bool risultato = false;

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Utente (nome,cognome,email) VALUES (@nom,@cogn,@email)";
                cmd.Parameters.AddWithValue("@nom", t.Nome);
                cmd.Parameters.AddWithValue("@cogn", t.Cognome);
                cmd.Parameters.AddWithValue("@email", t.Email);

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

        public bool Update(Utente t)
        {
            bool risultato = false;


            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE FROM Utente SET nome = @nom, cognome = @cgn, email= @ema";

                cmd.Parameters.AddWithValue("@nom",t.Nome);
                cmd.Parameters.AddWithValue("@cgn",t.Cognome);
                cmd.Parameters.AddWithValue("@ema",t.Email);


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
    }
}
