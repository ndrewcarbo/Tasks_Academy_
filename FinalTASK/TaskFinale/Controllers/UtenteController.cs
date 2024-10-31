using Microsoft.AspNetCore.Mvc;
using TaskFinale.Models;
using TaskFinale.Services;

namespace TaskFinale.Controllers
{
    public class UtenteController : Controller
    {

        private readonly UtenteService _utService;
        private readonly ILogger<UtenteController> _logger;

        public UtenteController(UtenteService utService, ILogger<UtenteController> logger)
        {
            _utService = utService;
            _logger = logger;
        }

        private bool isVerificato()
        {
            string? risultatoSess = HttpContext.Session.GetString("userLogged");
            if (risultatoSess is null && risultatoSess != "ADMIN")
                return false;

            return true;
        }

        public IActionResult Lista()
        {
            if (!isVerificato())
            {
                _logger.LogError("ORRORE, UTENTE NON VERIFICATO!!");
                return Redirect("/Auth/Login");

            }
            _logger.LogInformation("Utente VERIFICATO");
            IEnumerable<Utente> elenco = (IEnumerable<Utente>)_utService.List();

            return View(elenco);
        }


        public IActionResult InserisciUtente()
        {
            if (!isVerificato())
                return Redirect("/Auth/Login");

            return View();
        }
    }
}
