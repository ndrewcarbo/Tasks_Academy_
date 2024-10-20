using ViaGio_task.Context;
using ViaGio_task.Models;

namespace ViaGio_task.Repositories
{
    public class PacchettoRepos : IRepoLettura<Pacchetto>, IRepoScrittura<Pacchetto>
    {
        private readonly ViaGioContext _context;

        public PacchettoRepos(ViaGioContext context) {
        
            _context = context;
        }


        public bool Create(Pacchetto entity)
        {
            bool risultato = false;

            try
            {
                _context.Pacchetti.Add(entity);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            
            }

            return risultato;
        }

        public bool Delete(int id)
        {
            bool result = false;


            try
            {

                Pacchetto pc = _context.Pacchetti.Single(p => p.PacchettoID == id);
                _context.Pacchetti.Remove(pc);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public Pacchetto? Get(int id)
        {
            return _context.Pacchetti.Find(id);
        }

        public Pacchetto? GetByCodice(string codice)
        {
            return _context.Pacchetti.FirstOrDefault(c => c.Codice == codice);
        }

        public IEnumerable<Pacchetto> GetAll()
        {
            return _context.Pacchetti.ToList();
        }

        public bool Update(Pacchetto entity)
        {
            bool result = false;
            try
            {
                Pacchetto pac = _context.Pacchetti.Single(mod => mod.Codice == entity.Codice);

                entity.PacchettoID = pac.PacchettoID;
                entity.Codice = entity.Codice is not null ? entity.Codice : pac.Codice;
                entity.Nome = entity.Nome is not null ? entity.Nome : pac.Nome;
                entity.Durata = entity.Durata is not null ? entity.Durata : pac.Durata;
                entity.Prezzo = entity.Prezzo > 0 ? entity.Prezzo : pac.Prezzo;
                entity.Data_Iniz = entity.Data_Iniz = true ? entity.Data_Iniz : pac.Data_Iniz;
                entity.Data_Fine = entity.Data_Fine = true ? entity.Data_Fine : pac.Data_Fine;


                _context.Pacchetti.Add(entity);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

    }
}
