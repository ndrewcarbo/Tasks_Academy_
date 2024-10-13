using Microsoft.AspNetCore.Mvc;
using task_officina.Models;
using task_officina.Services;

namespace task_officina.Controllers
{

    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : Controller
    {

        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }


        [HttpGet("{varCodice}")]
        public ActionResult<ClienteDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            ClienteDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);


            return NotFound();
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> Registro()
        {

            return Ok(_service.RegistroClienti());
        }


        [HttpPost]
        public IActionResult NuovoClient(ClienteDTO newcli)
        {
            if (_service.InserisciCliente(newcli))
                return Ok();


            return BadRequest();
        }


        [HttpPut]
        public IActionResult ModificaProdotto(ClienteDTO obj)
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
            _service.RimuoviCliente(id);
            return Ok();
        }



    }
}
