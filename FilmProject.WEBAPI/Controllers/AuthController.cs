using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmProject.WEBAPI.Controllers
{
    public class AuthController : Controller
    {
        private IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("Auth")]
        public IActionResult Auth(string userName)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName)
            };

            var secret = _configuration["JWT:Key"];
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];

         
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    notBefore: DateTime.Now,
                    signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);


            return Ok(token);
        }
    }
}
