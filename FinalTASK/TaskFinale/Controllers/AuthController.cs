using Microsoft.AspNetCore.Mvc;
using TaskFinale.Models;
using TaskFinale.Services;

namespace TaskFinale.Controllers
{
    public class AuthController : Controller
    {
        private readonly AmministratoreServices _serviceADM;

        public AuthController(AmministratoreServices service)
        {
            _serviceADM = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verificato(AmministratoreDTO adDto)
        {

            if (string.IsNullOrWhiteSpace(adDto.Username) || string.IsNullOrWhiteSpace(adDto.Passw))
                return Redirect("/Auth/Login");

            if (_serviceADM.VerificaUsernamePassword(adDto))
            {
                HttpContext.Session.SetString("userLogged", "ADMIN");
                return Redirect("/Admin/Lista");
            }

            return Redirect("/Auth/Login");
        }
    }
}
