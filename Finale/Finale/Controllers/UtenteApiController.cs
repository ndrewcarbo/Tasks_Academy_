using Finale.Models;
using Finale.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Finale.Controllers
{
    [ApiController]
    [Route("api/profilo")]
    public class UtenteApiController : Controller
    {
        private readonly UtenteApiService _serviceAPI;

        public UtenteApiController(UtenteApiService serviceAPI)
        {
            _serviceAPI = serviceAPI;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UtenteDTO>> Lista()
        {
            return Ok(_serviceAPI.List());
        }

        
    }
}
