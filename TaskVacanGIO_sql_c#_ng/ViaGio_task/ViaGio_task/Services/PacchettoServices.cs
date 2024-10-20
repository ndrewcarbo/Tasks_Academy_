using ViaGio_task.Models;
using ViaGio_task.Repositories;

namespace ViaGio_task.Services
{
    public class PacchettoServices : IServiceLettura<PacchettoDTO>, IServiceScrittura<PacchettoDTO>
    {

        private readonly PacchettoRepos _repos;

        public PacchettoServices(PacchettoRepos repos)
        {
            _repos = repos;
        }

        public bool Aggiorna(PacchettoDTO entity)
        {
            bool risultato = false;

            if (entity.Cod is not null)
            {
                Pacchetto? upPac = _repos.GetByCodice(entity.Cod);

                if (upPac is not null && entity.Nom is not null && entity.Dur is not null)
                {
                    upPac.Nome = entity.Nom is not null ? entity.Nom : upPac.Nome;
                    upPac.Durata = entity.Dur is not null ? entity.Dur : upPac.Durata;

                    //todo controlla se funge

                    risultato = _repos.Update(upPac);
                };
            }
            return risultato;

        }

        public PacchettoDTO? CercaPerCodice(string codice)
        {
            PacchettoDTO? risultato = null;

           Pacchetto? pac = _repos.GetByCodice(codice);
            if (pac is not null)
            {
                risultato = new PacchettoDTO()
                {
                    Cod = pac.Codice,
                    Nom = pac.Nome,
                    Dur = pac.Durata,
                    Pre = pac.Prezzo,
                    DataI = pac.Data_Iniz,
                    DataF = pac.Data_Fine,

                };
            }
            
            return risultato;
        }

        public IEnumerable<PacchettoDTO> CercaTutti()
        {
            ICollection<PacchettoDTO> risultato = new List<PacchettoDTO>();
            IEnumerable<Pacchetto> pacchetti = _repos.GetAll();
            foreach(Pacchetto p in pacchetti)
            {
                PacchettoDTO temporanea = new PacchettoDTO()
                {
                    Cod = p.Codice,
                    Nom = p.Nome,
                    Dur = p.Durata,
                    Pre = p.Prezzo,
                    DataI = p.Data_Iniz,
                    DataF = p.Data_Fine,

                };
            risultato.Add(temporanea) ;
            }
            return risultato;

        }

        public bool Elimina(string codice)
        {
            bool risultato = false;

            Pacchetto? delPac = _repos.GetByCodice(codice);
            if (delPac is not null)
            {
                risultato = _repos.Delete(delPac.PacchettoID);
            }

            return risultato;
        }

        public bool Inserisci(PacchettoDTO entity)
        {

            Pacchetto nuovo = new Pacchetto()
            {
                Codice = entity.Cod is not null ? entity.Cod : Guid.NewGuid().ToString().ToUpper(),
                Nome = entity.Nom,
                Durata = entity.Dur,
                Prezzo = (decimal)entity.Pre,
                Data_Iniz = (DateOnly)entity.DataI,
                Data_Fine = (DateOnly)entity.DataF
            };

         
            return _repos.Create(nuovo);
;
        }
    }
}
