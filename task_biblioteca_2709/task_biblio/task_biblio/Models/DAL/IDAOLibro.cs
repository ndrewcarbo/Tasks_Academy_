using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace task_biblio.Models.DAL
{
    internal class IDAOLibro : IDAOLettura<Libro>, IDAOScrittura<Libro>
    {
        //===================SINGLETON=================

        private static IDAOLibro? instanza;

        public static IDAOLibro GetInstance()
        {
            if (instanza is null)
                instanza = new IDAOLibro();

            return instanza;
        }

        private IDAOLibro() { }


        //==================================

        //===================================
        //DELETE

        public bool Delete(int id)
        {
            bool risulstato = false;
            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Libro WHERE libroID = @varId ";

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

        public List<Libro> GetAll()
        {
            List<Libro> risultato = new List<Libro>();

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT libroID,codice,titolo,anno_pub,disponibilita FROM Libro";

                try
                {
                    conn.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        Libro temporaneo = new Libro()
                        {
                            Id = read.GetInt32(0),
                            Code = read.GetString(1),
                            Titolo = read.GetString(2),
                            Anno_pub = read.GetString(4),
                            Disp = read.GetBoolean(5),
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

        public Libro GetByCodice(string cod)
        {
            throw new NotImplementedException();
        }

        public Libro GetById(int id)
        {
            

            throw new NotImplementedException();
        }

        public bool Insert(Libro t)
        {
            bool risultato = false;

            using(SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Libro (titolo,anno_pub,disponibilita) VALUES (@tit,@annpub,@disp)";
                cmd.Parameters.AddWithValue("@tit", t.Titolo);
                cmd.Parameters.AddWithValue("@annpub", t.Anno_pub);
                cmd.Parameters.AddWithValue("@disp", t.Disp);

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

        public bool Update(Libro t)
        {
            bool risultato = false;


            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE FROM Libro SET titolo = @tit, anno_pub = @ann, disp= @dis";

                cmd.Parameters.AddWithValue("@tit", t.Titolo);
                cmd.Parameters.AddWithValue("@anno_pub", t.Anno_pub);
                cmd.Parameters.AddWithValue("@disp", t.Disp);


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
