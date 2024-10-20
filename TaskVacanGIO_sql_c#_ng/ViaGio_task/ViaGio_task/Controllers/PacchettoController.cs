using Microsoft.AspNetCore.Mvc;
using ViaGio_task.Models;
using ViaGio_task.Services;

namespace ViaGio_task.Controllers
{

    [ApiController]
    [Route("api/pacchetti")]
    public class PacchettoController : Controller
    {
        private readonly PacchettoServices _services;

        public PacchettoController(PacchettoServices services) { 
        
            _services = services;
        }
        
        
        [HttpGet("{varCodice}")]
        public ActionResult<PacchettoDTO?> VisualizzaPacchetto(string varCodice)
        {

            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            PacchettoDTO? risultato = _services.CercaPerCodice(varCodice);
            if(risultato is not null)
                return Ok(risultato);

            return NotFound();
            
            
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<PacchettoDTO>>ListaPacchetti()
        {

            return Ok(_services.CercaTutti());
        }

        [HttpPost]
        public IActionResult InserisciPachetto(PacchettoDTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nom) || string.IsNullOrWhiteSpace(obj.Dur))
                return BadRequest();


            if (_services.Inserisci(obj))
                return Ok();

            return BadRequest();
        }


        [HttpDelete]
        public IActionResult EliminaPacchetto(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            if (_services.Elimina(varCodice))
                return Ok();

            return BadRequest();
        }

        [HttpPut("{varCodice}")]
        public IActionResult AggiornaPacchetto(string varCodice, PacchettoDTO pacDto)
        {
            if (string.IsNullOrWhiteSpace(varCodice) ||
                string.IsNullOrWhiteSpace(pacDto.Nom) ||
                string.IsNullOrWhiteSpace(pacDto.Dur))
                return BadRequest();

            pacDto.Cod = varCodice;

            if (_services.Aggiorna(pacDto))
                return Ok();

            return BadRequest();
        }

    }
}
