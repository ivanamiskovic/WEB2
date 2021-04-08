using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web2_Backend.Configuration;
using Web2_Backend.Model;

namespace Web2_Backend.Controllers
{
    public class TokenController : DefaultController
    {
        public TokenController() { }

        public TokenController(ProjectConfiguration configuration) : base(configuration) 
        {
           
        }

        [HttpPost]
        public async Task<IActionResult> Post(User userData) 
        {
            if (userData == null || userData.Email == null || userData.Password == null) 
            {
                return BadRequest();
            }

            User user = userService.GetUserWithEmailAndPassword(userData.Email, userData.Password);

            if (user == null) 
            {
                return BadRequest("Invalide credentials");
            }

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, configuration.Jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", user.Name),
                new Claim("LastName", user.LastName),
                new Claim("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Jwt.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration.Jwt.Issuer, configuration.Jwt.Audience, expires: DateTime.UtcNow.AddDays(60), signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
