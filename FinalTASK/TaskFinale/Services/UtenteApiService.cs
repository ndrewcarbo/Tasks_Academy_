using TaskFinale.Models;
using TaskFinale.Repos;

namespace TaskFinale.Services
{
    public class UtenteApiService : IServiceLettura<UtenteDTO>
    {

        private readonly UtenteRepo _repou;

        public UtenteApiService(UtenteRepo repouT)
        {
            _repou = repouT;
        }


        public UtenteDTO? Details(int id)
        {
            throw new NotImplementedException();
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
    }
}
