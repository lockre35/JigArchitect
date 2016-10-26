using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jig.JigArchitect.Domain;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Manual.Seeds
{
    public class Seeder
    {
        public void Seed()
        {
            using(var db = new WrappedContext())
            {
                SeedLogins(db);
                db.SaveChanges();
            }
        }

        private void SeedLogins(WrappedContext context)
        {
            var login = new Login { Username = "Admin", Password = "password" };
            login.LoginClaims = new[] { new LoginClaim { Claim = new Claim { Name = "Admin" } } };
            context.Logins.Add(login);
        } 
    }
}
