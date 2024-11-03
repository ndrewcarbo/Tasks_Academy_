using Finale.Models;
using Finale.Repos;

namespace Finale.Services
{
    public class AdminServices
    {
        private readonly AmministratoreRepo _repo;

        public AdminServices(AmministratoreRepo repo)
        {
            _repo = repo;
        }

        public bool VerificaUsernamePassword(AmministratoreDTO adDto)
        {
            bool risultato = false;

            if (adDto.Username is not null && adDto.Passw is not null)
            {
                Amministratore? adm = _repo.GetByUsernamePassword(adDto.Username, adDto.Passw);
                if (adm is not null)
                    risultato = true;
            }

            return risultato;
        }

    }
}
