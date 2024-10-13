using Microsoft.AspNetCore.Mvc;
using task_ferramenta.Models;
using task_ferramenta.Services;

namespace task_ferramenta.Controllers
{


    [ApiController]
    [Route("api/prodotto")]
    public class ProdottoController : Controller
    {

        private readonly ProdottoService _service;

        public ProdottoController(ProdottoService service)
        {
            _service = service;
        }



        [HttpGet("{varCodice}")]
        public ActionResult<ProdottoDTO?> CercaPerCodice(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            ProdottoDTO? risultato = _service.Cerca(varCodice);
            if (risultato is not null)
                return Ok(risultato);


            return NotFound();
        }


        [HttpPost]
        public IActionResult InserisciProdotto(ProdottoDTO nuovoProd)
        {
            //if(string.IsNullOrWhiteSpace(nuovoProd.Nom) && string.IsNullOrWhiteSpace(nuovoProd.Desc) && nuovoProd.Prez < 0 && nuovoProd.Quan < 0)
            
                if (_service.InserisciProdotto(nuovoProd))
                return Ok();


                return BadRequest();

            
            //bool risultato = _service.InserisciProdotto(nuovoProd);

            //if (risultato)
            //    return Ok();

            //return BadRequest();
        }

        [HttpDelete]
        public IActionResult Elimina(int id)
        {
            _service.RimuoviProdotto(id);
            return Ok();
        }


        [HttpPut]
        public IActionResult ModificaProdotto(ProdottoDTO prObj)
        {
            if(prObj is not null)
            {
            _service.Modifica(prObj);
            return Ok();

            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdottoDTO>> guardaNelMagazzino()
        {

            return Ok(_service.Inventario());
        }
    }
}
