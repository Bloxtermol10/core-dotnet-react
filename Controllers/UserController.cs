using Core.Infraestructure;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Seguridad _seguridad;

        protected IConfiguration configuration;

        public UserController(Seguridad seguridad)
        {

            _seguridad = seguridad;
            configuration = _seguridad.configuration;
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
    }
}
