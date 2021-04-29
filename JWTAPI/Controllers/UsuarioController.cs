using JWTAPI.Model;
using JWTAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JWTAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [Authorize]
        [HttpGet("GetUsuarios")]
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                return await _usuarioRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetUsuario"), AllowAnonymous]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            try
            {
                var user = _usuarioRepository.GetById(id);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}