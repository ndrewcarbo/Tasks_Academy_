using Microsoft.EntityFrameworkCore;
using ViaGio_task.Context;
using ViaGio_task.Models;

namespace ViaGio_task.Repositories
{
    public class DestinazioneRepos : IRepoLettura<Destinazione>, IRepoScrittura<Destinazione>
    {

        private readonly ViaGioContext _context;

        public DestinazioneRepos(ViaGioContext context) {
        _context = context;
        
        }
        public bool Create(Destinazione entity)
        {
            bool risultato = false;

            try
            {
                _context.Destinazioni.Add(entity);
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

                Destinazione des = _context.Destinazioni.Single(p => p.DestinazioneID == id);
                _context.Destinazioni.Remove(des);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public Destinazione? Get(int id)
        {
            return _context.Destinazioni.Find(id);
        }

        public Destinazione? CercaByNome(string varNom)
        {
            return _context.Destinazioni.FirstOrDefault(n => n.Nome == varNom);
        }

        public IEnumerable<Destinazione> GetAll()
        {
            return _context.Destinazioni.ToList();
        }

        public bool Update(Destinazione entity)
        {
            bool result = false;
            try
            {
                Destinazione des = _context.Destinazioni.Single(mod => mod.Nome == entity.Nome);

                entity.DestinazioneID = des.DestinazioneID;
                entity.Nome = entity.Nome is not null ? entity.Nome : des.Nome;
                entity.Descrizione = entity.Descrizione is not null ? entity.Descrizione : des.Descrizione;
                entity.Paese = entity.Paese is not null ? entity.Paese : des.Paese;
                entity.Immagine = entity.Immagine = true ? entity.Immagine : des.Immagine;


                _context.Destinazioni.Add(entity);
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
