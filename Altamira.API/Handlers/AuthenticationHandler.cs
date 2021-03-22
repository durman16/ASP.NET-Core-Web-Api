using Altamira.DataAccess;
using Altamira.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Altamira.API.Handlers
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AltamiraDbContext _context;
        public AuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            AltamiraDbContext context)
            : base(options, logger, encoder, clock)
        {
            _context = context;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorizaiton header yok");
            try
            {
                var authenticationvalue = AuthenticationHeaderValue.Parse(Request.Headers["Authentication"]);
                var bytes = Convert.FromBase64String(authenticationvalue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string emailAddress = credentials[0];
                string password = credentials[1];
                User user = (User)_context.Users.Where(user => user.email == emailAddress && user.password == password);
                if (user == null)
                    return AuthenticateResult.Fail("Please Login");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.email) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Please Login");
            }
            
        }
    }
}
