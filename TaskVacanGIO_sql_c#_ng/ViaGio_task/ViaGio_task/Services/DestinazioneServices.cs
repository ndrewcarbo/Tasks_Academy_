using ViaGio_task.Models;
using ViaGio_task.Repositories;

namespace ViaGio_task.Services
{
    public class DestinazioneServices : IServiceLettura<DestinazioneDTO>, IServiceScrittura<DestinazioneDTO>
    {
        private readonly DestinazioneRepos _repos;

        public DestinazioneServices(DestinazioneRepos repos)
        {
            _repos = repos;
        }

        public bool Aggiorna(DestinazioneDTO entity)
        {
            bool risultato = false;

            if (entity.Nom is not null)
            {
                Destinazione? des = _repos.CercaByNome(entity.Nom);

                if (des is not null && entity.Nom is not null && entity.Des is not null && entity.Pae is not null && entity.Imm is not null)
                {
                    des.Nome = entity.Nom is not null ? entity.Nom : des.Nome;
                    des.Descrizione = entity.Des is not null ? entity.Des : des.Descrizione;
                    des.Paese = entity.Pae is not null ? entity.Pae : des.Paese;
                    des.Immagine = entity.Imm is not null ? entity.Imm : des.Immagine;

                    risultato = _repos.Update(des);
                };
            }

            return risultato;
        }

        public DestinazioneDTO? CercaPerCodice(string varCod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DestinazioneDTO> CercaTutti()
        {
            ICollection<DestinazioneDTO> risultato = new List<DestinazioneDTO>();
            IEnumerable<Destinazione> destinazioni = _repos.GetAll();
            foreach (Destinazione d in destinazioni)
            {
                DestinazioneDTO temporanea = new DestinazioneDTO()
                {
                    Nom = d.Nome,
                    Des = d.Descrizione,
                    Pae = d.Paese,
                    Imm = d.Immagine

                };
                risultato.Add(temporanea);
            }
            return risultato;
        }

        public bool Elimina(string nome)
        {
            bool risultato = false;

            Destinazione? des = _repos.CercaByNome(nome);
            if (des is not null)
            {
                risultato = _repos.Delete(des.DestinazioneID);
            }

            return risultato;
        }

        public bool Inserisci(DestinazioneDTO entity)
        {
            Destinazione nuovo = new  Destinazione()
            {
                Nome = entity.Nom,
                Descrizione = entity.Des,
                Paese = entity.Pae,
                Immagine = entity.Imm
            };


            return _repos.Create(nuovo);
        }

        public DestinazioneDTO? DestinazionePerNome(string varNome)
        {
            DestinazioneDTO? risulatato = null;
                
            Destinazione? destinazione = _repos.CercaByNome(varNome);
            if (destinazione is not null)
            {
                risulatato = new DestinazioneDTO()
                {
                    Nom = destinazione.Nome,
                    Des = destinazione.Descrizione,
                    Pae = destinazione.Paese,
                    Imm = destinazione.Immagine

                };
            }


            return risulatato;
        }
    }
}
