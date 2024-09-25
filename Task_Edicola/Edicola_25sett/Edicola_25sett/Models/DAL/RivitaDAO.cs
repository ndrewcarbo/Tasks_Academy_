using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Edicola_25sett.Models.DAL
{
    internal class RivitaDAO : IDaoLettura<Rivista> , IDaoScrittura<Rivista>
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



        private static RivitaDAO instance;

        public static RivitaDAO GetInstance()
        {
            if (instance == null)
                instance = new RivitaDAO();

            return instance;
        }

        private RivitaDAO() { }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rivista> GetAll()
        {
            throw new NotImplementedException();
        }

        public Rivista GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Rivista t)
        {
            bool risult = false;

            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand;
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Rivista (rivistaID,codiceAbarre,titolo,prezzo,casaEditrice) VALUES (@Id, @codice,@titolo,@price,@casaed)";


                cmd.Parameters.AddWithValue($"@Id,{temp.Id}");
                cmd.Parameters.AddWithValue($"@codice,{temp.Codice}");
                cmd.Parameters.AddWithValue($"@titolo,{temp.Titolo}");
                cmd.Parameters.AddWithValue($"@price,{temp.Prezzo}");
                cmd.Parameters.AddWithValue($"@casaed,{temp.Casaedit}");
            }

            return risult;
            
            throw new NotImplementedException();
        }

        public bool Update(Rivista t)
        {
            throw new NotImplementedException();
        }



        // tutte le riviste by codice
        public void GetByCodiceaBarre(int varCod)
        {
            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT rivistaID, codiceAbarre, titolo, prezzo, casaEditrice FROM Rivista WHERE codiceAbarre = @cod ";
                cmd.Parameters.AddWithValue("@cod", varCod);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Rivista temp = new Rivista()
                        {
                            Id = reader.GetInt32(0),
                            Codice = reader.GetInt32(1),
                            Titolo = reader.GetString(2),
                            Prezzo = reader.GetFloat(3),
                            Casaedit = reader.GetString(4)
                        };

                        Console.WriteLine(temp);
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

            }

        }



    }
}
