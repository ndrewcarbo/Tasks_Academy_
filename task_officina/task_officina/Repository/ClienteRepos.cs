using Microsoft.EntityFrameworkCore;
using task_officina.Models;

namespace task_officina.Repository
{
    public class ClienteRepos : IRepository<Cliente>
    {
        private readonly OfficinaContext _context;

        public ClienteRepos(OfficinaContext context)
        {
            _context = context;
        }

        //C

        public bool Create(Cliente entity)
        {
            bool result = false;
            try
            {
                _context.Clienti.Add(entity);
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

                Cliente cl = _context.Clienti.Single(c => c.ClienteID == id);
                _context.Clienti.Remove(cl);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clienti.ToList();
        }

        public Cliente? GetbyId(int id)
        {
            return _context.Clienti.Find(id);
        }

        //U
        public bool Update(Cliente entity)
        {
            bool result = false;
            try
            {
                Cliente cli = _context.Clienti.Single(mod => mod.Codice == entity.Codice);

                entity.ClienteID = cli.ClienteID;
                entity.Codice = entity.Codice is not null ? entity.Codice : cli.Codice;
                entity.Nome = entity.Nome is not null ? entity.Nome : cli.Nome;
                entity.Cognome = entity.Cognome is not null ? entity.Cognome : cli.Cognome;
                entity.Email = entity.Email is not null ? entity.Email : cli.Email;
                entity.Indirizzo = entity.Indirizzo is not null ? entity.Indirizzo : cli.Indirizzo;
                entity.Telefono = entity.Telefono is not null ? entity.Telefono : cli.Telefono;


                _context.Clienti.Add(entity);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }


        public Cliente? CercaperCodice(string varCod)
        {
            return _context.Clienti.FirstOrDefault(c => c.Codice == varCod);
        }

        
    }
}
