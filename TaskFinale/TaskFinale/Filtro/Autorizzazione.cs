using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskFinale.Filtro
{
    public class Autorizzazione : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }


        //todo ricorda il tipo utente se imprementare questa funzionalità
        
    }
}
