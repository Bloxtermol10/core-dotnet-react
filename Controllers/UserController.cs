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
        [AllowAnonymous]
        [HttpGet]
        [Route("login")]
        
        public dynamic IniciarSesion([FromQuery] string userName, string password)
        {
            try
            {
                var res = _seguridad.validarUsuario(userName, password);
                if (res == true)
                {
                    var user = _seguridad.getUsuario(userName);


                    var jwt = _seguridad.configuration.GetSection("Jwt").Get<Jwt>();

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("id", user.IdUsuario.ToString()),
                        new Claim("userName", userName)
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: sigIn
                        );

                    var writeToken = new JwtSecurityTokenHandler().WriteToken(token);

                    user.Token = writeToken;
                    return Ok(user);
                };
                return StatusCode(401, "Usuario Incorrecto");

            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }


        }

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
