using Microsoft.AspNetCore.Mvc;
using TaskFinale.Filtro;

namespace TaskFinale.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {

        [HttpGet("profilo")]
        [Autorizzazione("ADMIN")]
        public IActionResult Profilo()
        {
            return Ok(new
            {
                status = "SUCCESS",
                dati = "Profilo dell'amministratore"
            });
        }
    }
}
