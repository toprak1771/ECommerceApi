using _StarbucksApi.Data;
using _StarbucksApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _StarbucksApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly StarbucksContext _context;
        private readonly IConfiguration _config;

        public AuthController(StarbucksContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginResource) 
        {
            var findedUser = await _context.Users.Where(x => x.Email == loginResource.Email).SingleOrDefaultAsync();
            if (findedUser == null)
                return BadRequest("Kullanıcı bulunamadı");
            if (!BCrypt.Net.BCrypt.Verify(loginResource.Password, findedUser.Password))
                return BadRequest("Kullanıcı adı veya şifre hatalı");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "starbucks",
                Issuer = "issuer",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, findedUser.FullName),
                    new Claim(ClaimTypes.Email, findedUser.Email),
                    new Claim("Role", findedUser.Role.ToString())
                }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
            
        }
    }
}
