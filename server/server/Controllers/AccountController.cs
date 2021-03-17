using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AccountController(AppDbContext context, IConfiguration Config)
        {
            _context = context;
            _config = Config;
        }

        // POST : api/Account
        [HttpPost]
        public async Task<ActionResult<User>> Login(User user)
        {
            if (user != null)
            {
               var userFound = await _context.User.SingleAsync(u => u.Username == user.Username);

                if (userFound != null)
                    //return Ok(GenerateJsonWebToken(userFound));
                    return userFound;
                else
                    return NotFound();
            }
            return BadRequest();
               
        }

        /*public void Logout(User user)
        {
            if (user != null)
              DiscardJsonWebToken(user);
        }*/

        private User GenerateJsonWebToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.UTF8.GetBytes(this._config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.Email, user.Email),

                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(
                  new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }

        private void DiscardJsonWebToken(User user) {}
    }
}
