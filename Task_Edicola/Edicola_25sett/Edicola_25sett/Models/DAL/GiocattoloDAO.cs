using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edicola_25sett.Models.DAL
{
    internal class GiocattoloDAO : IDaoLettura<Giocattolo>, IDaoScrittura<Giocattolo>
    {
        // -------------------- SINGLETON
        private static GiocattoloDAO? instance;

        public static GiocattoloDAO GetInstance()
        {
            if (instance == null)
                instance = new GiocattoloDAO();

            return instance;
        }



        private GiocattoloDAO() { }
        //-------------------------------------
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Giocattolo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Giocattolo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Giocattolo t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Giocattolo t)
        {
            throw new NotImplementedException();
        }


        // tutti i giocattoli by codice a barre

        public void GetByCodiceaBarre(int varCod)
        {
            using (SqlConnection conn = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT giocattoloID, codiceAbarre, nome, materiale, prezzo eta_min FROM Giocattolo WHERE codiceAbarre = @cod ";
                cmd.Parameters.AddWithValue("@cod", varCod);


                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Giocattolo temp = new Giocattolo()
                        {
                            Id = reader.GetInt32(0),
                            Codice = reader.GetInt32(1),
                            Nome = reader.GetString(2),
                            Materiale = reader.GetString(3),
                            Prezzo = reader.GetFloat(4),
                            Eta = reader.GetInt32(5)
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
}
