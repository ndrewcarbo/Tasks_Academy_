using Finale.Models;
using Finale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finale.Controllers
{
    public class UtenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly UtenteServices _service;
        private readonly ILogger<UtenteController> _logger;

        public UtenteController(UtenteServices service, ILogger<UtenteController> logger)
        {
            _service = service;
            _logger = logger;
        }

        private bool IsAutorizzato()
        {
            string? risultatoSess = HttpContext.Session.GetString("userLogged");
            if (risultatoSess is null && risultatoSess != "ADMIN")
                return false;

            return true;
        }

        public IActionResult Lista()
        {
            if (!IsAutorizzato())
            {
                _logger.LogError("Errore, utente non autorizzato sull'endpoint Corso/Lista");
                return Redirect("/Auth/Login");
            }


            _logger.LogInformation("Utente autorizzato a vedere Lista");
            IEnumerable<Utente> elenco = (IEnumerable<Utente>)_service.List();

            return View(elenco);
        }

        public IActionResult Inserisci()
        {
            if (!IsAutorizzato())
                return Redirect("/Auth/Login");

            return View();
        }

        [HttpPost]
        public IActionResult Salva(UtenteDTO utDto)
        {
            if (!IsAutorizzato())
            {
                _logger.LogError("Errore, utente non autorizzato sull'endpoint Utente/Salva");
                return Redirect("/Auth/Login");
            }

            if (utDto.Username is null)
            {
                HttpContext.Session.SetString("errore", "Attenzione il nome non può essere vuoto");
                return Redirect("/Error/Error");
            }

            if (_service.Insert(utDto))
                return Redirect("/Utente/Lista");

            HttpContext.Session.SetString("errore", "Errore di inserimento del Utente");
            return Redirect("/Error/Error");
        }
    }
}
