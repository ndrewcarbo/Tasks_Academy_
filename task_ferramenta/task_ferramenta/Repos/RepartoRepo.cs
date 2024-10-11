using task_ferramenta.Models;

namespace task_ferramenta.Repos
{
    public class RepartoRepo : IRepos<Reparto>
    {

        //======================================
        private readonly FerramentaCtx _context;

        public RepartoRepo(FerramentaCtx context)
        {
            _context = context;
        }
        //=======================================
        //==================interfaccia=============
        public bool Create(Reparto entity)
        {
            bool result = false;
            try
            {
                _context.Repartos.Add(entity);
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

                Reparto repa = _context.Repartos.Single(r => r.RepartoId == id);
                _context.Repartos.Remove(repa);
                _context.SaveChanges();


                result = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            return result;
        }

        public Reparto? Get(int id)
        {
            return _context.Repartos.Find(id);
        }

        public IEnumerable<Reparto> GetAll()
        {
            return _context.Repartos.ToList();
        }

        public bool Update(Reparto entity)
        {
            bool result = false;
            try
            {
                Reparto temporanea = _context.Repartos.Single(repa => repa.RepartoCod == entity.RepartoCod);

                entity.RepartoId = temporanea.RepartoId;
                entity.RepartoCod = entity.RepartoCod is not null ? entity.RepartoCod : temporanea.RepartoCod;
                entity.Nome = entity.Nome is not null ? entity.Nome : temporanea.Nome;
                entity.Fila = entity.Fila is not null ? entity.Fila : temporanea.Fila;


                _context.Repartos.Add(entity);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        //==================INTERFACCIA====================================
    }
}
