using task_ferramenta.Models;

namespace task_ferramenta.Repos
{
    public class ProdottoRepo : IRepos<Prodotto>
    {

        //======================================
        private readonly FerramentaCtx _context;

        public ProdottoRepo(FerramentaCtx context)
        {
            _context = context;
        }
        //======================================



        //====================INTERFACCIAA=======================================

        public bool Create(Prodotto entity)
        {
            bool result = false;
            try
            {
                _context.Prodottos.Add(entity);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;


            try
            {

                Prodotto pr = _context.Prodottos.Single(p => p.ProdottoId == id);
                _context.Prodottos.Remove(pr);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public Prodotto? Get(int id)
        {
            return _context.Prodottos.Find(id);
        }

        public Prodotto? CercaperCodice(string varCode)
        {
            return _context.Prodottos.FirstOrDefault(c => c.CodiceBarre == varCode);
        }

        public IEnumerable<Prodotto> GetAll()
        {
            return _context.Prodottos.ToList();

        }

        public bool Update(Prodotto entity)
        {
            bool result = false;
            try
            {
                Prodotto temporanea = _context.Prodottos.Single(prd => prd.CodiceBarre == entity.CodiceBarre);

                entity.ProdottoId = temporanea.ProdottoId;
                entity.CodiceBarre = entity.CodiceBarre is not null ? entity.CodiceBarre : temporanea.CodiceBarre;
                entity.Nome = entity.Nome is not null ? entity.Nome : temporanea.Nome;
                entity.Descrizione = entity.Descrizione is not null ? entity.Descrizione : temporanea.Descrizione;
                entity.Prezzo = entity.Prezzo is not null ? entity.Prezzo : temporanea.Prezzo;
                entity.Quantita = entity.Quantita != 0 ? entity.Quantita : temporanea.Quantita;


                _context.Prodottos.Add(entity);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        //====================INTERFACCIAA=======================================



    }
}
