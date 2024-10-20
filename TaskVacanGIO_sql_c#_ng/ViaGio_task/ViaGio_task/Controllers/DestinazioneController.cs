using Microsoft.AspNetCore.Mvc;
using ViaGio_task.Models;
using ViaGio_task.Services;

namespace ViaGio_task.Controllers
{

    [ApiController]
    [Route("api/destinazioni")]
    public class DestinazioneController : Controller
    {
        private readonly DestinazioneServices _services;

        public DestinazioneController(DestinazioneServices services)
        {

            _services = services;
        }



        [HttpGet("{varNome}")]
        public ActionResult<DestinazioneDTO?> CercaDestinazione(string varNome)
        {

            if (string.IsNullOrWhiteSpace(varNome))
                return BadRequest();

            DestinazioneDTO? risultato = _services.DestinazionePerNome(varNome);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();



        }

        [HttpGet]
        public ActionResult<IEnumerable<DestinazioneDTO>> ListaDestinazioni()
        {

            return Ok(_services.CercaTutti());
        }



        [HttpPost]
        public IActionResult InserisciDestinazione(DestinazioneDTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nom) || string.IsNullOrWhiteSpace(obj.Pae) || string.IsNullOrWhiteSpace(obj.Imm) || string.IsNullOrWhiteSpace(obj.Des))
                return BadRequest();


            if (_services.Inserisci(obj))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{varNome}")]
        public IActionResult EliminaDestinazione(string varNome)
        {
            if (string.IsNullOrWhiteSpace(varNome))
                return BadRequest();

            if (_services.Elimina(varNome))
                return Ok();

            return BadRequest();
        }

        [HttpPut("{varNome}")]
        public IActionResult AggiornaDestinazione(string varNome, DestinazioneDTO objDes)
        {
            if (string.IsNullOrWhiteSpace(varNome) ||
                string.IsNullOrWhiteSpace(objDes.Nom) ||
                string.IsNullOrWhiteSpace(objDes.Imm) ||
                string.IsNullOrWhiteSpace(objDes.Pae) ||
                string.IsNullOrWhiteSpace(objDes.Des))
                return BadRequest();

            objDes.Nom = varNome;

            if (_services.Aggiorna(objDes))
                return Ok();

            return BadRequest();
        }
    }
}
