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
                SeedApplications(db);
                SeedServices(db);
                SeedSchemas(db);
            }
        }

        private void SeedLogins(WrappedContext context)
        {
            if (context.Logins.Any(x => x.Username == "Admin"))
                return;

            var login = new Login { Username = "Admin", Password = "password" };
            login.LoginClaims = new[] { new LoginClaim { Claim = new Claim { Name = "Admin" } } };
            context.Logins.Add(login);
            context.SaveChanges();
        }

        private void SeedApplications(WrappedContext context)
        {
            if (context.Applications.Any(x => x.Name == "JigArchitect"))
                return;

            var application = new Application { Name = "JigArchitect" };
            context.Applications.Add(application);
            context.SaveChanges();
        }

        private void SeedServices(WrappedContext context)
        {
            if (context.Services.Any(x => x.Name == "Application"))
                return;

            var service = new Service { Name = "Application", PluralName = "Applications" };
            service.Application = context.Applications.Single(x => x.Name == "JigArchitect");
            context.Services.Add(service);
            context.SaveChanges();
        }

        private void SeedSchemas(WrappedContext context)
        {
            if (context.Schemas.Any(x => x.Name == "Api"))
                return;

            var schema = new Schema { Name = "Api" };
            schema.Application = context.Applications.Single(x => x.Name == "JigArchitect");
            context.Schemas.Add(schema);
            context.SaveChanges();
        }
    }
}
