using JWTAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        public readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("GetToken"), AllowAnonymous]
        public IActionResult RequestToken([FromBody]Usuario user)
        {
            try
            {
                if (user.Login.Equals("leonardo") && user.Senha.Equals("123"))
                {
                    return Ok(new { token = GerarToken(user) });
                }
                else
                {
                    return BadRequest("Credenciais inválidas...");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GerarToken(Usuario user)
        {
            var claims = new[]
            {
             new Claim("login", user.Login),
             new Claim("nome", user.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));

            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                                             audience: _configuration["Jwt:Audience"],
                                             claims: claims,
                                             expires: DateTime.Now.AddMinutes(10),
                                             signingCredentials: credencials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}