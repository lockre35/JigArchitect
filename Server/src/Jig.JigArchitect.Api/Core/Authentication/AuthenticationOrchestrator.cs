using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using Jig.JigArchitect.Api.Models;
using Jig.JigArchitect.Manual;
using Jig.JigArchitect.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jig.JigArchitect.Api.Orchestrators
{
    public class AuthenticationOrchestrator
    {
        private const int HoursTokenValid = 24;
        private const string IdentityType = "TokenAuth";
        private TokenOptionsModel tokenOptionsModel;

        public AuthenticationOrchestrator(TokenOptionsModel tokenOptionsModel)
        {
            this.tokenOptionsModel = tokenOptionsModel;
        }

        public dynamic Authenticate(AuthenticationModel model)
        {
            // Obviously, at this point you need to validate the username and password against whatever system you wish.
            var userId = CheckCredentials(model.Username, model.Password);
            if (userId > 0)
            {
                DateTime? expires = DateTime.UtcNow.AddHours(HoursTokenValid);
                var token = GetToken(model.Username, expires, userId);
                return new { authenticated = true, entityId = 1, token = token, tokenExpires = expires, name = model.Username };
            }
            return new { authenticated = false };
        }

        private string GetToken(string user, DateTime? expires, int userId)
        {
            var handler = new JwtSecurityTokenHandler();

            // Here, you should create or look up an identity for the user which is being authenticated.
            // For now, just creating a simple generic identity.
            var claims = GetClaims(userId);
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user, IdentityType), claims);

            var jwt = new JwtSecurityToken(
                issuer: tokenOptionsModel.Issuer,
                audience: tokenOptionsModel.Audience,
                claims: GetClaims(userId),
                expires: expires,
                signingCredentials: tokenOptionsModel.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return handler.WriteToken(jwt);
        }

        private Claim[] GetClaims(int userId)
        {
            //if (userId == 1)
            //{
            //    return new[] { new Claim("Admin", userId.ToString()) };
            //}
            //else if (userId == 2)
            //{
            //    return new[] { new Claim("Manager", userId.ToString()) };
            //}
            //else
            //{
            //    return new[] { new Claim("Manager", userId.ToString()) };
            //}

            using (var db = new DomainContext())
            {
                var login = db.Logins.Include(x => x.LoginClaims)
                    .ThenInclude(x => x.Claim)
                    .Single(x => x.LoginId == userId);
                var claims = login.LoginClaims.Select(x => new Claim(x.Claim.Name, login.LoginId.ToString()));
                return claims.ToArray();
            }
        }

        private int CheckCredentials(string userName, string password)
        {

            //if (userName == "Admin" && password == "password")
            //{
            //    return 1;
            //}
            //else if (userName == "Manager" && password == "password")
            //{
            //    return 2;
            //}
            //else if (userName == "Manager" && password == "password")
            //{
            //    return 3;
            //}


            using (var db = new DomainContext())
            {
                var logins = db.Logins.Where(x => x.Username == userName && x.Password == password).ToList();
                if(logins.Count() != 1)
                {
                    return 0;
                }
                else
                {
                    return logins.First().LoginId;
                }
            }
        }
    }
}