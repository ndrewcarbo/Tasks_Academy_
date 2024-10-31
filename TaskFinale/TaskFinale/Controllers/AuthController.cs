using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult Login(Login objLogin)
        //{
        //    if (string.IsNullOrWhiteSpace(objLogin.Username) || string.IsNullOrWhiteSpace(objLogin.Password))
        //        return BadRequest();

        //    if (objLogin.Username == "Andrea" && objLogin.Password == "pipe")
        //    {
        //        objLogin.UserType = "ADMIN";
        //    }
        //    if (objLogin.Username == "PROFGiovanni" && objLogin.Password == "genio")
        //    {
        //        objLogin.UserType = "USER";
        //    }

        //    if (objLogin.UserType is not null)
        //    {
        //        List<Claim> claimsList = new List<Claim>()
        //        {
        //            new Claim(JwtRegisteredClaimNames.Sub, objLogin.Username),
        //            new Claim("userType", objLogin.UserType),
        //        };

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("scrivi_Qualcosa_Ma_Cosa_si_infatti"));
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken(
        //            issuer: "taskfinale.com",
        //            audience: "Sudditi",
        //            claims: claimsList,
        //            expires: DateTime.Now.AddHours(1),
        //            signingCredentials: creds
        //        );

        //        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        //    }

        //    return NotFound();
        //}




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
