using Core.Infraestructure;
using Core.Models;
using Core.ORM;
using Core.ORM.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Seguridad _seguridad;

        protected IConfiguration configuration;
        private readonly DbContext _context;


        public UserController(Seguridad seguridad, DbContext context)
        {

            _seguridad = seguridad;
            configuration = _seguridad.configuration;
            _context = context;
        }
        [Authorize(Policy = "Admon")]
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            try
            {
                var user = _seguridad.getUsuario(nombre);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("info")]
        public IActionResult Info() {
            try
            {
                var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                // Leer el token JWT y extraer el IdUser
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null)
                {
                    return Unauthorized(new { message = "Token inválido" });
                }
                var idUserClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "IdUser")?.Value;

                if (idUserClaim == null)
                {
                    return Unauthorized(new { message = "Token inválido" });
                }
                var usuario = _context.Set<Usuario>().ToList().FirstOrDefault(user => user.idUsuario == Convert.ToInt32(idUserClaim));
                if (usuario != null)
                {
                    var nombre = usuario.nombreUsuario;
                    var user = _seguridad.getUsuario(nombre);
                    return Ok(user);
                }
                else
                {
                    return StatusCode(500, "Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
