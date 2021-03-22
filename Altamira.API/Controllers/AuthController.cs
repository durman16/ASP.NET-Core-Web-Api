using Altamira.API.Models;
using Altamira.Bussiness.Abstract;
using Altamira.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Altamira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthService _authService;
        public AuthController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
            _config = config;
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginUser login)
        {
            string email = login.email;
            string password = login.password;
            IActionResult response = Unauthorized();
            User user = _authService.AuthenticateUser(email, password);
            if(user != null)
            {
                var tokenstr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenstr });
            }
            return response;/*

            UserWithToken userWithToken = null;

            if (user != null)
            {
                RefreshToken refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);
                await _context.SaveChangesAsync();

                userWithToken = new UserWithToken(user);
                userWithToken.RefreshToken = refreshToken.Token;
            }

            if (userWithToken == null)
            {
                return NotFound();
            }

            //sign your token here here..
            userWithToken.AccessToken = GenerateAccessToken(user.UserId);
            return userWithToken;*/
        }
        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.email),
                new Claim(JwtRegisteredClaimNames.Sub,user.password),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer:_config["Jwt:Issuer"],
                audience:_config["Jwt:Issuer"],
                claims,
                expires:DateTime.Now.AddMinutes(120),
                signingCredentials:credentials
                );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        /*
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<UserWithToken>> RegisterUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            //load role for registered user
            user = await _context.Users.Include(u => u.Role)
                                        .Where(u => u.UserId == user.UserId).FirstOrDefaultAsync();

            UserWithToken userWithToken = null;

            if (user != null)
            {
                RefreshToken refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);
                await _context.SaveChangesAsync();

                userWithToken = new UserWithToken(user);
                userWithToken.RefreshToken = refreshToken.Token;
            }

            if (userWithToken == null)
            {
                return NotFound();
            }

            //sign your token here here..
            userWithToken.AccessToken = GenerateAccessToken(user.UserId);
            return userWithToken;
        }*/
    }
    
}
