using task_ferramenta.Models;
using task_ferramenta.Repos;

namespace task_ferramenta.Services
{
    public class ProdottoService : IService<ProdottoDTO>
    {

        private readonly ProdottoRepo _repository;

        public ProdottoService(ProdottoRepo repository)
        {
            _repository = repository;
        }


        public ProdottoDTO? Cerca(string varCod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdottoDTO> Lista()
        {
            throw new NotImplementedException();
        }

        public bool InserisciProdotto(ProdottoDTO nuovoProd)
        {
            Prodotto pr = new Prodotto()
            {
                CodiceBarre=nuovoProd.Cod is not null ? nuovoProd.Cod : Guid.NewGuid().ToString(),
                Nome=nuovoProd.Nom,
                Descrizione=nuovoProd.Desc,
                Prezzo=nuovoProd.Prez,
                Quantita=(int)nuovoProd.Quan,
            };

            return _repository.Create(pr);
            
            
            

           
        }

        public bool RimuoviProdotto(int id)
        {
            bool risultato = false;

            Prodotto? pr = _repository.Get(id);
            if (pr is not null)
                _repository.Delete(id);
                risultato= true;

            return risultato;
            
        }

        public bool Modifica(ProdottoDTO prodMod)
        {
            bool risultato = false;


            Prodotto temp = new Prodotto()
            {
                Prezzo = prodMod.Prez,
                Quantita = (int)prodMod.Quan
            };

            return _repository.Update(temp);
        }
    }
}
