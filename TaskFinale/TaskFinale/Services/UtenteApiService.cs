using TaskFinale.Models;
using TaskFinale.Repos;

namespace TaskFinale.Services
{
    public class UtenteApiService : IServiceLettura<UtenteDTO>, IServiceScrittura<UtenteDTO>
    {

        private readonly UtenteRepo _repou;
        private readonly UtenteService _utenteService;
        private readonly ILogger<UtenteApiService> _logger;

        public UtenteApiService(UtenteRepo repoUT, UtenteService utenteService, ILogger<UtenteApiService> logger)
        {
            _repou = repoUT;
            _utenteService = utenteService;
            _logger = logger;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UtenteDTO? Details(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UtenteDTO t)
        {
            Utente nuovo = new Utente()
            {
                Codice = t.Codice is not null ? t.Codice : Guid.NewGuid().ToString().ToUpper(),
                Username = t.Username,
                Passw = t.Passw,
                Email = t.Email
            };


            return _repou.Create(nuovo);
        }

        public IEnumerable<UtenteDTO> List()
        {
            IEnumerable<UtenteDTO> list = (IEnumerable<UtenteDTO>)_repou.GetAll();

            List<UtenteDTO> risultato = new List<UtenteDTO>();

            foreach (UtenteDTO u in list)
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

        public bool Update(UtenteDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
