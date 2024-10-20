using ViaGio_task.Models;
using ViaGio_task.Repositories;

namespace ViaGio_task.Services
{
    public class RecensioniServices : IServiceLettura<RecensioneDTO>, IServiceScrittura<RecensioneDTO>
    {
        private readonly RecensioneRepos _repos;

        public RecensioniServices(RecensioneRepos repo)
        {
            _repos = repo;
        }

        public bool Aggiorna(RecensioneDTO entity)
        {
            bool risultato = false;

            if (entity.Cod is not null)
            {
                Recensione? upRec = _repos.GetByCodice(entity.Cod);

                if (upRec is not null && entity.Cod is not null && entity.Com is not null && entity.NomUt is not null)
                {
                    upRec.NomeUtente = entity.NomUt is not null ? entity.NomUt : upRec.NomeUtente;
                    upRec.Commento = entity.Com is not null ? entity.Com : upRec.Commento;

                    //todo controlla se funge

                    risultato = _repos.Update(upRec);
                };
            }
            return risultato;
        }

        public RecensioneDTO? CercaPerCodice(string varCod)
        {
            RecensioneDTO? risultato = null;

            Recensione? pac = _repos.GetByCodice(varCod);
            if (pac is not null)
            {
                risultato = new RecensioneDTO()
                {
                    Cod = pac.Codice,
                    NomUt = pac.NomeUtente,
                    Vot = pac.Voto,
                    Com = pac.Commento,
                    DatR = pac.Data_Rec

                };
            }

            return risultato;
        }

        public IEnumerable<RecensioneDTO> CercaTutti()
        {
            ICollection<RecensioneDTO> risultato = new List<RecensioneDTO>();
            IEnumerable<Recensione> recensioni = _repos.GetAll();
            foreach (Recensione r in recensioni)
            {
                RecensioneDTO temporanea = new RecensioneDTO()
                {
                    Cod = r.Codice,
                    NomUt = r.NomeUtente,
                    Vot = r.Voto,
                    Com = r.Commento,
                    DatR = r.Data_Rec
                };
                risultato.Add(temporanea);
            }
            return risultato;
        }

        public bool Elimina(string codice)
        {
            bool risultato = false;

            Recensione? delRec = _repos.GetByCodice(codice);
            if (delRec is not null)
            {
                risultato = _repos.Delete(delRec.RecensioneID);
            }

            return risultato;
        }

        public bool Inserisci(RecensioneDTO entity)
        {
            Recensione nuovo = new Recensione()
            {
                Codice = entity.Cod is not null ? entity.Cod : Guid.NewGuid().ToString().ToUpper(),
                NomeUtente = entity.NomUt,
                Voto = (int)entity.Vot,
                Commento = entity.Com,
                Data_Rec = (DateOnly)entity.DatR
            };


            return _repos.Create(nuovo);
        }
    }
}
