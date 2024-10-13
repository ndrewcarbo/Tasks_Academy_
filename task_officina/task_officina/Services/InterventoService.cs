using task_officina.Models;
using task_officina.Repository;

namespace task_officina.Services
{
    public class InterventoService : IService<InterventoDTO>
    {
        private readonly InterventoRepos _repository;

        public InterventoService(InterventoRepos repository)
        {
            _repository = repository;
        }

        public InterventoDTO? Cerca(string varCod)
        {
            InterventoDTO? risultato = null;

            Intervento? inter = _repository.CercaperCodice(varCod);
            if (inter is not null)
            {
                risultato = new InterventoDTO()
                {
                    Cod = inter.Codice,
                    Tar = inter.Targa,
                    Mod = inter.Modello,
                    Mar = inter.Marca,
                    Ann = inter.Anno,
                    Sta = inter.Stato,
                    Data_st = inter.Data_start,
                };
            }
            return risultato;
        }

        public IEnumerable<InterventoDTO> Lista()
        {
            ICollection<InterventoDTO> risultato = new List<InterventoDTO>();

            IEnumerable<Intervento> intervents = _repository.GetAll();

            foreach (Intervento i in intervents)
            {

                InterventoDTO inter = new InterventoDTO()
                {
                    Cod = i.Codice,
                    Tar = i.Targa,
                    Mod = i.Modello,
                    Mar = i.Marca,
                    Ann = i.Anno,
                    Pre = i.Prezzo,
                    Sta = i.Stato,
                    Data_st = i.Data_start,
                };

                risultato.Add(inter);
            }
            return risultato;
        }

        public bool InserisciIntervento(InterventoDTO newint)
        {
            Intervento inter = new Intervento()
            {
                Codice = newint.Cod is not null ? newint.Cod : Guid.NewGuid().ToString().ToUpper(),
                Targa = newint.Tar,
                Modello = newint.Mod,
                Marca = newint.Mar,
                Anno = newint.Ann,
                Prezzo = newint.Pre,
                Stato = newint.Sta,
                Data_start = newint.Data_st,
            };

            return _repository.Create(inter);
        }

        public bool Modifica(InterventoDTO objmod)
        {


            Intervento temp = new Intervento()
            {
                Prezzo = objmod.Pre,
                Stato = objmod.Sta,
                Data_start = objmod.Data_st
            };
            return _repository.Update(temp);
        }


        public bool RimuoviIntervento(int id)
        {
            bool risultato = false;

            Intervento? del = _repository.GetbyId(id);
            if (del is not null)
                _repository.Delete(id);
            risultato = true;

            return risultato;

        }
    }
}
