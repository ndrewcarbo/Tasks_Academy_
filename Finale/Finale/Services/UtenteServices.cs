using Finale.Models;
using Finale.Repos;

namespace Finale.Services
{
    public class UtenteServices : IServicesLett<UtenteDTO>, IServiceScrittura<UtenteDTO>
    {

        private readonly UtenteRepo _repoUT;

        public UtenteServices(UtenteRepo repoUT)
        {
            _repoUT = repoUT;
        }
        public bool Delete(int id)
        {
            bool risultato = false;

            Utente? delUT = _repoUT.GetById(id);
            if (delUT is not null)
            {
                risultato = _repoUT.Delete(delUT.UtenteId);
            }

            return risultato;
        }

        public UtenteDTO? Details(int id)
        {
            throw new NotImplementedException();

            //PROFILO UTENTE?
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


            return _repoUT.Create(nuovo);
        }

        public IEnumerable<UtenteDTO> List()
        {
            return (IEnumerable<UtenteDTO>)_repoUT.GetAll();
        }

        public bool Update(UtenteDTO t)
        {
            bool risultato = false;

            if (t.Codice is not null)
            {
                Utente? upUT = _repoUT.GetByCodice(t.Codice);

                if (upUT is not null && t.Username is not null && t.Passw is not null)
                {
                    upUT.Username = t.Username is not null ? t.Username : upUT.Username;
                    upUT.Passw = t.Passw is not null ? t.Passw : upUT.Passw;

                    //todo controlla se funge

                    risultato = _repoUT.Update(upUT);
                };
            }
            return risultato;
        }


        public UtenteDTO? CercaPerCodice(string codice)
        {
            UtenteDTO? risultato = null;

            Utente? utente = _repoUT.GetByCodice(codice);
            if (utente is not null)
            {
                risultato = new UtenteDTO()
                {
                    Codice = utente.Codice,
                    Username = utente.Username,
                    Email = utente.Email,
                    Passw = utente.Passw,
                };
            }

            return risultato;
        }
    }
}
