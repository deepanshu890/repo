using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Company.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Company.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        ICompanyRepository rep;
        public AuthController(ICompanyRepository _rep)
        {
            rep = _rep;
        }
        [HttpPost]
        public IActionResult Login(DAL.Models.SuperUsers user)
        {
            if (user == null)
                return BadRequest("Invalid request");

            bool status = false;
            status = rep.ValidateCredentials(user);

            if(status)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer : "https://localhost:44336",
                    audience : "https://localhost:44336",
                    claims : new List<Claim>(),
                    expires : DateTime.Now.AddMinutes(5),
                    signingCredentials : signingCredentials
                    );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
