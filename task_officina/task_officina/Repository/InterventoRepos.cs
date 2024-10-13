using Microsoft.EntityFrameworkCore;
using task_officina.Models;

namespace task_officina.Repository
{
    public class InterventoRepos : IRepository<Intervento>
    {

        private readonly OfficinaContext _context;

        public InterventoRepos(OfficinaContext context)
        {
            _context = context;
        }

        //C 

        public bool Create(Intervento entity)
        {
            bool result = false;
            try
            {
                _context.Interventi.Add(entity);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        //D
        public bool Delete(int id)
        {
            bool result = false;


            try
            {

                Intervento pr = _context.Interventi.Single(p => p.InterventoID == id);
                _context.Interventi.Remove(pr);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public IEnumerable<Intervento> GetAll()
        {
            throw new NotImplementedException();
        }

        //ID
        public Intervento? GetbyId(int id)
        {
            return _context.Interventi.Find(id);
        }

        //U

        public bool Update(Intervento entity)
        {
            bool result = false;
            try
            {
                Intervento intervento = _context.Interventi.Single(mod => mod.Codice == entity.Codice);

                entity.InterventoID = intervento.InterventoID;
                entity.Codice = entity.Codice is not null ? entity.Codice : intervento.Codice;
                entity.Targa = entity.Targa is not null ? entity.Targa : intervento.Targa;
                entity.Modello = entity.Modello is not null ? entity.Modello : intervento.Modello;
                entity.Marca = entity.Marca is not null ? entity.Marca : intervento.Marca;
                entity.Anno = entity.Anno > 2024 ? entity.Anno : intervento.Anno;
                entity.Prezzo = entity.Prezzo > 0 ? entity.Prezzo : intervento.Prezzo;
                entity.Stato = entity.Stato is not null ? entity.Stato : intervento.Stato;
                entity.Data_start = entity.Data_start < DateTime.Now ? entity.Data_start : intervento.Data_start;


                _context.Interventi.Add(entity);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public Intervento? CercaperCodice(string varCod)
        {
            return _context.Interventi.FirstOrDefault(c => c.Codice == varCod);
        }
    }
}
