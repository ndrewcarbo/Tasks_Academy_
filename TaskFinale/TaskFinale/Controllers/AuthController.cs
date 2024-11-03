using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskFinale.Models;
using TaskFinale.Services;

namespace TaskFinale.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("login")]             
        public IActionResult Login(Login objLogin)
        {
            if (string.IsNullOrWhiteSpace(objLogin.Username) || string.IsNullOrWhiteSpace(objLogin.Password))
                return BadRequest();

            if (objLogin.Username == "Andrea" && objLogin.Password == "pipe")
            {
                objLogin.UserType = "ADMIN";
            }
            if (objLogin.Username == "Giovanni" && objLogin.Password == "Genius")
            {
                objLogin.UserType = "USER";
            }

            if (objLogin.UserType is not null)
            {
                List<Claim> claimsList = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, objLogin.Username),
                    new Claim("userType", objLogin.UserType),
                    //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("giovanni_genio_giovanni_genio_giovanni_genio_giovanni_genio_giovanni_genio"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "http://localhost:5292",
                    audience: "Sudditi",
                    claims: claimsList,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return NotFound();
        }
    }

}