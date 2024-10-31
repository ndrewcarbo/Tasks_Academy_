using Microsoft.EntityFrameworkCore;
using TaskFinale.Context;
using TaskFinale.Models;

namespace TaskFinale.Repos
{
    public class UtenteRepo : IReposLettura<Utente> , IReposScrittura<Utente>
    {
        private readonly FinaleContext _context;

        public UtenteRepo(FinaleContext context)
        {

            _context = context;
        }


        public Utente? GetByCodice(string codice)
        {
            return _context.Utentes.FirstOrDefault(c => c.Codice == codice);
        }

        public bool Create(Utente entity)
        {
            bool risultato = false;

            try
            {
                _context.Utentes.Add(entity);
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

                Utente ut = _context.Utentes.Single(U => U.UtenteId == id);
                _context.Utentes.Remove(ut);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utentes.ToList();
        }

        public Utente? GetById(int id)
        {
           return _context.Utentes.Find(id);
        }

        public bool Update(Utente entity)
        {
            bool result = false;
            try
            {
                Utente ut = _context.Utentes.Single(mod => mod.Codice == entity.Codice);

                entity.UtenteId = ut.UtenteId;
                entity.Codice = entity.Codice is not null ? entity.Codice : ut.Codice;
                entity.Username = entity.Username is not null ? entity.Username : ut.Username;
                entity.Passw = entity.Passw is not null ? entity.Passw : ut.Passw;
                entity.Email = entity.Email is not null ? entity.Email : ut.Email;
              


                _context.Utentes.Add(entity);
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
