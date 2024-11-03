using Finale.Models;
using Finale.Repos;

namespace Finale.Services
{
    public class UtenteApiService
    {
        private readonly UtenteRepo _repo;

        public UtenteApiService(UtenteRepo repo)
        {
            _repo = repo;
        }

        public UtenteDTO? Details(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UtenteDTO> List()
        {
            IEnumerable<Utente> lista = _repo.GetAll();

            List<UtenteDTO> risultato = new List<UtenteDTO>();

            foreach (Utente u in lista)
            {
                risultato.Add(new UtenteDTO()
                {
                    Codice = u.Codice,
                    Username = u.Username,
                    Email = u.Email,
                    Passw = u.Passw
                });
            }

            return risultato;
        }
    }
}
