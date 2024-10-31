using Microsoft.AspNetCore.Mvc;
using TaskFinale.Models;
using TaskFinale.Services;

namespace TaskFinale.Controllers
{
    [ApiController]
    [Route("api/utente")]
    public class UtenteApiController : Controller
    {

        private readonly UtenteApiService _serviceAPI;

        public UtenteApiController(UtenteApiService service)
        {
            _serviceAPI = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UtenteDTO>> Lista()
        {
            return Ok(_serviceAPI.List());
        }

    }
}
