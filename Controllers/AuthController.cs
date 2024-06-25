using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Infraestructure;
using Core.Models;
using Core.ORM;
using Core.ORM.Entities;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private Seguridad _seguridad;
        private readonly IConfiguration configuration;
        private readonly DbContext _context;

        public AuthController(IConfiguration config, Seguridad seguridad, DbContext context)
        {
            configuration = config;
            _seguridad = seguridad;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("RequestToken")]
        public IActionResult RequestToken()
        {
            DateTime utcNow = DateTime.UtcNow;

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(utcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                
            };

            DateTime expiredDateTime = utcNow.AddDays(1);

            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                notBefore: utcNow,
                expires: expiredDateTime,
                signingCredentials: signingCredentials
            );

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            string jwtToken = jwtTokenHandler.WriteToken(token);

            return new JsonResult(new { token = jwtToken });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]

        public IActionResult IniciarSesion([FromBody] LoginRequest  loginRequest)
        {
            var userName = loginRequest.UserName;
            var password = loginRequest.Password;


            try
            {
                var res = _seguridad.validarUsuario(userName, password);
                var user = _context.Set<Usuario>().ToList().FirstOrDefault(user => user.clave == password);
                if (res == true && user != null)
                {
                    DateTime utcNow = DateTime.UtcNow;

                    List<Claim> claims = new List<Claim>
                      {
                          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                          new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(utcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                          new Claim("Rol","Admon"),
                          new Claim("IdUser", user.idUsuario.ToString()),
                      };

                    DateTime expiredDateTime = utcNow.AddDays(1);

                    var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
                    var symmetricSecurityKey = new SymmetricSecurityKey(key);
                    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        claims: claims,
                        notBefore: utcNow,
                        expires: expiredDateTime,
                        signingCredentials: signingCredentials
                    );

                    var jwtTokenHandler = new JwtSecurityTokenHandler();
                    string jwtToken = jwtTokenHandler.WriteToken(token);


                    return Ok(new JsonResult(new { token = jwtToken }));

                };
                return StatusCode(401, "Usuario Incorrecto");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


    }
}
