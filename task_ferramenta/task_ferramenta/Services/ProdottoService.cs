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
            ProdottoDTO? risultato = null;

            Prodotto? prod = _repository.CercaperCodice(varCod);
            if (prod is not null )
            {
                risultato = new ProdottoDTO()
                {
                    Cod = prod.CodiceBarre,
                    Nom = prod.Nome,
                    Desc = prod.Descrizione,
                    Prez = prod.Prezzo,
                    Quan = prod.Quantita
                };
            }


            return risultato;
        }

        public IEnumerable<ProdottoDTO> Inventario()
        {
            ICollection<ProdottoDTO> risultato = new List<ProdottoDTO>();

            IEnumerable<Prodotto> prodotti = _repository.GetAll();

            foreach (Prodotto p  in prodotti) {

                ProdottoDTO prod = new ProdottoDTO()
                {
                    Cod = p.CodiceBarre,
                    Nom = p.Nome,
                    Desc = p.Descrizione,
                    Prez = p.Prezzo,
                    Quan = p.Quantita
                };

                risultato.Add(prod);
            }


            return risultato;
        }

        public bool InserisciProdotto(ProdottoDTO nuovoProd)
        {
            Prodotto pr = new Prodotto()
            {
                CodiceBarre = nuovoProd.Cod is not null ? nuovoProd.Cod : Guid.NewGuid().ToString().ToUpper(),
                Nome = nuovoProd.Nom!,
                Descrizione = nuovoProd.Desc,
                Prezzo  = nuovoProd.Prez,
                Quantita = (int)nuovoProd.Quan!,
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


            Prodotto temp = new Prodotto()
            {
                Prezzo = prodMod.Prez,
                Quantita = (int)prodMod.Quan!
            };
            return _repository.Update(temp);
        }

        public IEnumerable<ProdottoDTO> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
