using ViaGio_task.Context;
using ViaGio_task.Models;

namespace ViaGio_task.Repositories
{
    public class RecensioneRepos : IRepoLettura<Recensione>, IRepoScrittura<Recensione>
    {

        private readonly ViaGioContext _context;

        public RecensioneRepos(ViaGioContext context) {
            _context = context;
        
        }
        public bool Create(Recensione entity)
        {
            bool risultato = false;

            try
            {
                _context.Recensioni.Add(entity);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return risultato;
        }

        public bool Delete(int id)
        {
            bool result = false;


            try
            {

                Recensione rec = _context.Recensioni.Single(p => p.RecensioneID == id);
                _context.Recensioni.Remove(rec);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public Recensione? Get(int id)
        {
            return _context.Recensioni.Find(id);
        }
        public Recensione? GetByCodice(string varCod)
        {
            return _context.Recensioni.FirstOrDefault(c => c.Codice == varCod);
        }


        public IEnumerable<Recensione> GetAll()
        {
            return _context.Recensioni.ToList();
        }

        public bool Update(Recensione entity)
        {
            bool result = false;
            try
            {
                Recensione rec = _context.Recensioni.Single(mod => mod.Codice == entity.Codice);

                entity.RecensioneID = rec.RecensioneID;
                entity.Codice = entity.Codice is not null ? entity.Codice : rec.Codice;
                entity.NomeUtente = entity.NomeUtente is not null ? entity.NomeUtente : rec.NomeUtente;
                entity.Voto = entity.Voto > 0  ? entity.Voto : rec.Voto;
                entity.Commento = entity.Commento is not null ? entity.Commento : rec.Commento;
                entity.Data_Rec = entity.Data_Rec = true ? entity.Data_Rec : rec.Data_Rec;
                entity.pacchettoRIF = entity.pacchettoRIF = true ? entity.pacchettoRIF : rec.pacchettoRIF;


                _context.Recensioni.Add(entity);
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
