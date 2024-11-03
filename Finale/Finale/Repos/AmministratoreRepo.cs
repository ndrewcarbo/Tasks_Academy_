using Finale.Ctx;
using Finale.Models;

namespace Finale.Repos
{
    public class AmministratoreRepo
    {
        private readonly FinaleContext _context;

        public AmministratoreRepo(FinaleContext context)
        {
            _context = context;
        }


        public Amministratore? GetByUsernamePassword(string user, string pass)
        {
            return _context.Amministratore.FirstOrDefault(a => a.Username == user && a.Passw == pass);
        }
    }
}
