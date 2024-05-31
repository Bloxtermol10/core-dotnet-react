using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public LoginUserController(IConfiguration config)
        {
            configuration = config;
        }

        [AllowAnonymous]
        [HttpGet("RequestToken")]
        public IActionResult RequestToken()
        {
            DateTime utcNow = DateTime.UtcNow;

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(utcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
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
    }
}
