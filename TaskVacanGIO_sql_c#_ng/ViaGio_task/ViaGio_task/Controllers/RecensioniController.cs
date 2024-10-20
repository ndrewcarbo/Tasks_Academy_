using Microsoft.AspNetCore.Mvc;
using ViaGio_task.Models;
using ViaGio_task.Services;

namespace ViaGio_task.Controllers
{

    [ApiController]
    [Route("api/recensioni")]
    public class RecensioniController : Controller
    {

        private readonly RecensioniServices _services;

        public RecensioniController(RecensioniServices services)
        {

            _services = services;
        }

        [HttpGet("{varCodice}")]
        public ActionResult<RecensioneDTO?> VisualizzaRecensione(string varCodice)
        {

            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            RecensioneDTO? risultato = _services.CercaPerCodice(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<RecensioneDTO>> ListaRecensioni()
        {

            return Ok(_services.CercaTutti());
        }

        [HttpPost]
        public IActionResult InserisciRecensione(RecensioneDTO obj)
        {
            //if (string.IsNullOrWhiteSpace(obj.Nom) || string.IsNullOrWhiteSpace(obj.Dur))
            //    return BadRequest();


            if (_services.Inserisci(obj))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaRecensione(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            if (_services.Elimina(varCodice))
                return Ok();

            return BadRequest();
        }

        [HttpPut("{varCodice}")]
        public IActionResult AggiornaCliente(string varCodice, RecensioneDTO objRec)
        {
            if (string.IsNullOrWhiteSpace(varCodice) ||
                string.IsNullOrWhiteSpace(objRec.Com) ||
                string.IsNullOrWhiteSpace(objRec.NomUt))
                return BadRequest();

            objRec.Cod = varCodice;

            if (_services.Aggiorna(objRec))
                return Ok();

            return BadRequest();
        }
    }
}
