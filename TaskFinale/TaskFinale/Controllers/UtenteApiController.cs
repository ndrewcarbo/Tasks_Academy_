using Microsoft.AspNetCore.Mvc;
using TaskFinale.Models;
using TaskFinale.Services;

namespace TaskFinale.Controllers
{
    [ApiController]
    [Route("api/profilo")]
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


        [HttpPost]
        public IActionResult Inserisci(UtenteDTO utDTO)
        {
            if (
                string.IsNullOrWhiteSpace(utDTO.Username) ||
                string.IsNullOrWhiteSpace(utDTO.Passw) ||
                string.IsNullOrWhiteSpace(utDTO.Email))
                return BadRequest();

            if (_serviceAPI.Insert(utDTO))
                return Ok();

            return BadRequest();
        }

    }
}
