using Microsoft.AspNetCore.Mvc;
using task_officina.Models;
using task_officina.Services;

namespace task_officina.Controllers
{

    [ApiController]
    [Route("api/intervento")]
    public class InterventoController : Controller
    {

        private readonly InterventoService _service;

        public InterventoController(InterventoService service)
        {
            _service = service;
        }


        [HttpGet("{varCodice}")]
        public ActionResult<InterventoDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            InterventoDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);


            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<InterventoDTO>> RegistroInterventi()
        {

            return Ok(_service.Lista());
        }

        [HttpPost]
        public IActionResult NuovoIntervento(InterventoDTO newinter)
        {
            if (_service.InserisciIntervento(newinter))
                return Ok();


            return BadRequest();
        }


        [HttpPut]
        public IActionResult ModificaIntervento(InterventoDTO obj)
        {
            if (obj is not null)
            {
                _service.Modifica(obj);
                return Ok();

            }

            return BadRequest();
        }


        [HttpDelete]
        public IActionResult Elimina(int id)
        {
            _service.RimuoviIntervento(id);
            return Ok();
        }

    }
}
