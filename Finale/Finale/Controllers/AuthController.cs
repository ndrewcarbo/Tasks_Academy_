using Finale.Models;
using Finale.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finale.Controllers
{
    public class AuthController : Controller
    {

        private readonly AdminServices _service;

        public AuthController(AdminServices service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verifica(AmministratoreDTO adDto)
        {

            if (string.IsNullOrWhiteSpace(adDto.Username) || string.IsNullOrWhiteSpace(adDto.Passw))
                return Redirect("/Auth/Login");

            if (_service.VerificaUsernamePassword(adDto))
            {
                HttpContext.Session.SetString("userLogged", "ADMIN");
                return Redirect("/Utente/Lista");
            }

            return Redirect("/Auth/Login");
        }


        [HttpPost]
        public IActionResult VerificaCredenziali(Utente utente)
        {

            if (string.IsNullOrWhiteSpace(utente.Passw) || string.IsNullOrWhiteSpace(utente.Username))
                return Redirect("/Auth/Login");

            if (utente.Username == "andrea" && utente.Passw == "pipe")     
            {
                HttpContext.Session.SetString("utenteLoggato", "ADMIN");
                return Redirect("/Admin/DashboardAdm");
            }

            if (utente.Username == "Prof" && utente.Passw == "Genio")      
            {
                HttpContext.Session.SetString("utenteLoggato", "USER");
                return Redirect("/User/Elenco");
            }

            return Redirect("/Auth/Login");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Auth/Login");

        }
    }
}
