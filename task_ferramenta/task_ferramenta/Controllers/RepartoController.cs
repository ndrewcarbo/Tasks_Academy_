using Microsoft.AspNetCore.Mvc;
using task_ferramenta.Models;
using task_ferramenta.Services;

namespace task_ferramenta.Controllers
{

    [ApiController]
    [Route("api/reparto")]
    public class RepartoController : Controller
    {

        private readonly RepartoService _service;

        public RepartoController(RepartoService service)
        {
            _service = service;
        }


        [HttpGet("{varCodice}")]
        public ActionResult CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            RepartoDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);


            return NotFound();
        }
    }
}
