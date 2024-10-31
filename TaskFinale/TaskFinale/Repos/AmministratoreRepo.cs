using TaskFinale.Context;
using TaskFinale.Models;

namespace TaskFinale.Repos
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
            return _context.Adimns.FirstOrDefault(a => a.Username == user && a.Passw == pass);
        }
    }
        
}
